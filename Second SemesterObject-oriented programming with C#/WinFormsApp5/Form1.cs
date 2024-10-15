using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;


namespace WinFormsApp5
{
    public partial class FormOne : Form
    {
        private bool isDragging = false;
        private Point offset;
        private List<Figure> figures = new List<Figure>();
        private Figure selectedFigure = null;
        private Color selectedColor = Color.Black;
        private Stack<List<Figure>> undoStack = new Stack<List<Figure>>();
        private Stack<List<Figure>> redoStack = new Stack<List<Figure>>();
        private Point startPoint;

        private Shape? selectedShape = null;

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, 
            WriteIndented = true 
        };
        public FormOne()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in figures)
            {
                figure.Draw(e.Graphics);
            }
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedFigure != null)
            {

                selectedFigure.Position = new Point(e.X - offset.X, e.Y - offset.Y);
                Invalidate();
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Figure figure in figures)
                {
                    if (figure.IsPointInside(e.Location))
                    {
                        selectedFigure = figure;
                        isDragging = true;
                        offset = new Point(e.Location.X - selectedFigure.Position.X, e.Location.Y - selectedFigure.Position.Y);
                        Invalidate();
                        break;
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            selectedFigure = null;
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedFigure == null)
                {

                    switch (selectedShape)
                    {
                        case Shape.Circle:
                            Figure newCircle = new Circle(e.Location, 50, selectedColor);
                            figures.Add(newCircle);
                            selectedFigure = newCircle;
                            break;
                        case Shape.Triangle:
                            Figure newTriangle = new Triangle(e.Location, 50, selectedColor);
                            figures.Add(newTriangle);
                            selectedFigure = newTriangle;
                            break;
                        case Shape.Rectangle:
                            Figure newRectangle = new Rectangle(e.Location, 50, 50, selectedColor);
                            figures.Add(newRectangle);
                            selectedFigure = newRectangle;
                            break;
                        case Shape.Line:
                            if (startPoint.IsEmpty)
                            {
                                startPoint = e.Location;
                            }
                            else
                            {
                                Figure newLine = new Line(startPoint, e.Location, selectedColor);
                                figures.Add(newLine);
                                selectedFigure = newLine;
                                undoStack.Push(new List<Figure>(figures));
                                startPoint = Point.Empty;
                            }
                            break;
                    }

                    redoStack.Clear();
                    undoStack.Push(new List<Figure>(figures));
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

                foreach (Figure figure in figures)
                {
                    if (figure.IsPointInside(e.Location))
                    {
                        selectedFigure = figure;
                        isDragging = true;
                        offset = new Point(e.Location.X - selectedFigure.Position.X, e.Location.Y - selectedFigure.Position.Y);
                        Invalidate();
                        break;
                    }
                }
            }

        }

        private void btnSelectRectangle_Click(object sender, EventArgs e)
        {
            selectedShape = selectedShape == Shape.Rectangle ? null : Shape.Rectangle;

        }


        private void btnSelectTriangle_Click(object sender, EventArgs e)
        {
            selectedShape = selectedShape == Shape.Triangle ? null : Shape.Triangle;
        }

        private void btnSelectCircle_Click(object sender, EventArgs e)
        {
            selectedShape = selectedShape == Shape.Circle ? null : Shape.Circle;
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
            }
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new List<Figure>(figures));
                figures = undoStack.Pop();
                selectedFigure = null;
                Refresh();
            }
            else
            {
                figures.Clear();
            }
            Refresh();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new List<Figure>(figures));
                figures = redoStack.Pop();
                selectedFigure = null;
            }
            Refresh();
        }


        private void btnSelectLine_Click(object sender, EventArgs e)
        {
            selectedShape = selectedShape == Shape.Line ? null : Shape.Line;
        }
        private void FormOne_Load(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            figures.Clear();
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !string.IsNullOrEmpty(textBox1.Text))
            {
                
                string shapeName = textBox1.Text;

                List<Figure> filteredFigures = figures.Where(figure =>
                {
                    if (figure is Circle && shapeName.Equals("Circle", StringComparison.OrdinalIgnoreCase))
                        return true;
                    else if (figure is Triangle && shapeName.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                        return true;
                    else if (figure is Rectangle && shapeName.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
                        return true;
                    else if (figure is Line && shapeName.Equals("Line", StringComparison.OrdinalIgnoreCase))
                        return true;
                    else
                        return false;
                }).ToList();

                
                figures = filteredFigures;

                
                Invalidate();
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked && !string.IsNullOrEmpty(textBox2.Text))
            {
                
                string colorName = textBox2.Text;

                
                figures = figures.Where(figure =>
                {
                    
                    if (figure.Color.Name.Equals(colorName, StringComparison.OrdinalIgnoreCase))
                        return true;
                    else
                        return false;
                }).ToList();
            }
            Invalidate();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                
                var groupedFigures = figures.GroupBy(figure => figure.GetType())
                                            .OrderByDescending(group => group.Count());

                
                var mostCommonFigureType = groupedFigures.FirstOrDefault()?.Key;

                
                if (mostCommonFigureType != null)
                {
                    textBox3.Text = mostCommonFigureType.Name;
                }
                else
                {
                    textBox3.Text = "No figures";
                }
            }
            else
            {
                textBox3.Text = string.Empty;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
               
                Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();

                
                foreach (Figure figure in figures)
                {
                    if (colorCounts.ContainsKey(figure.Color))
                    {
                        colorCounts[figure.Color]++;
                    }
                    else
                    {
                        colorCounts[figure.Color] = 1;
                    }
                }

                
                Color mostCommonColor = colorCounts.OrderByDescending(kvp => kvp.Value)
                                                   .Select(kvp => kvp.Key)
                                                   .FirstOrDefault();

                
                if (mostCommonColor != null)
                {
                    textBox4.Text = mostCommonColor.ToString();
                }
                else
                {
                    textBox4.Text = "No figures";
                }
            }
            else
            {
                textBox4.Text = string.Empty;
            }

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    try
                    {
                        
                        string json = JsonSerializer.Serialize(figures, options);

                       
                        File.WriteAllText(fileName, json);

                        MessageBox.Show("Figures were successfully saved to a file.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    try
                    {
                     
                        string jsonFromFile = File.ReadAllText(fileName);

                       
                        List<Figure> loadedFigures = JsonSerializer.Deserialize<List<Figure>>(jsonFromFile, options);

                        if (loadedFigures != null && loadedFigures.Any())
                        {
                            
                            figures.Clear();
                            figures.AddRange(loadedFigures);

                           
                            undoStack.Clear();
                            redoStack.Clear();

                            
                            Invalidate();

                            MessageBox.Show("Figures were successfully loaded from the file.", "Load Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The loaded file does not contain any figures.", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while loading: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }



    public enum Shape
    {
        Circle,
        Triangle,
        Rectangle,
        Line
    }
}
