namespace Cubo_EsferaMovGraficas;

public partial class Form1 : Form
{


    private int posCuboX = 0;
    private int posCuboY = 0;

    private int posCuboZ = 0;

    private int posEsferaX = 0;
    private int posEsferaY = 0;

    private int posEsferaZ = 0;

    private int paralelos = 5;  
    private int meridianos = 10; 

    public Form1()
    {
        InitializeComponent();

        this.Text = "Cubo y Esfera en Movimiento";
        this.ClientSize = new Size(800, 450);
        this.BackColor = Color.White;
        this.Paint += Form1_Paint;

        CrearBotones();
    }

private void CrearBotones()
    {

        Label lblInstrucciones = new Label()
        {
            Text = "Botones Cubo:",
            Location = new Point(10, 0),
            AutoSize = true
        };

        this.Controls.Add(lblInstrucciones);

        Button btnXMas = new Button() { Text = "+X", Location = new Point(10, 20), Width = 40 };
        btnXMas.Click += (s, e) => { posCuboX += 10; this.Invalidate(); }; // Invalidate() fuerza el repintado
        
        Button btnXMenos = new Button() { Text = "-X", Location = new Point(55, 20), Width = 40 };
        btnXMenos.Click += (s, e) => { posCuboX -= 10; this.Invalidate(); };

        Button btnYMas = new Button() { Text = "+Y", Location = new Point(10, 50), Width = 40 };
        btnYMas.Click += (s, e) => { posCuboY -= 10; this.Invalidate(); };
        
        Button btnYMenos = new Button() { Text = "-Y", Location = new Point(55, 50), Width = 40 };
        btnYMenos.Click += (s, e) => { posCuboY += 10; this.Invalidate(); };

        Button btnZMas = new Button() { Text = "+Z", Location = new Point(10, 80), Width = 40 };
        btnZMas.Click += (s, e) => { posCuboZ -= 10; this.Invalidate(); };
        
        Button btnZMenos = new Button() { Text = "-Z", Location = new Point(55, 80), Width = 40 };
        btnZMenos.Click += (s, e) => { posCuboZ += 10; this.Invalidate(); };



        Label lblInstruccionesEsfera = new Label()
        {
            Text = "Botones Esfera:",
            Location = new Point(10, 110),
            AutoSize = true
        };

        this.Controls.Add(lblInstruccionesEsfera);

        Button btnXMasEsfera = new Button() { Text = "+X", Location = new Point(10, 130), Width = 40 };
        btnXMasEsfera.Click += (s, e) => { posEsferaX += 10; this.Invalidate(); }; // Invalidate() fuerza el repintado
        
        Button btnXMenosEsfera = new Button() { Text = "-X", Location = new Point(55, 130), Width = 40 };
        btnXMenosEsfera.Click += (s, e) => { posEsferaX -= 10; this.Invalidate(); };

        Button btnYMasEsfera = new Button() { Text = "+Y", Location = new Point(10, 160), Width = 40 };
        btnYMasEsfera.Click += (s, e) => { posEsferaY -= 10; this.Invalidate(); };
        
        Button btnYMenosEsfera = new Button() { Text = "-Y", Location = new Point(55, 160), Width = 40 };
        btnYMenosEsfera.Click += (s, e) => { posEsferaY += 10; this.Invalidate(); };
    
        Button btnZMasEsfera = new Button() { Text = "+Z", Location = new Point(10, 190), Width = 40 };
        btnZMasEsfera.Click += (s, e) => { posEsferaZ -= 10; this.Invalidate(); };
        
        Button btnZMenosEsfera = new Button() { Text = "-Z", Location = new Point(55, 190), Width = 40 };
        btnZMenosEsfera.Click += (s, e) => { posEsferaZ += 10; this.Invalidate(); };


        Label lbSizeEsfera = new Label()
        {
            Text = "Cantidad Caras esfera:",
            Location = new Point(10, 220),
            AutoSize = true
        };

        this.Controls.Add(lbSizeEsfera);

        Button btnAumentarParalelos = new Button() { Text = "+P", Location = new Point(10, 240), Width = 40 };
        btnAumentarParalelos.Click += (s, e) => { paralelos += 1; this.Invalidate(); };
        Button btnDisminuirParalelos = new Button() { Text = "-P", Location = new Point(55, 240), Width = 40 };
        btnDisminuirParalelos.Click += (s, e) => { if (paralelos > 1) paralelos -= 1; this.Invalidate(); };


        this.Controls.Add(btnXMenosEsfera);
        this.Controls.Add(btnXMasEsfera);
        this.Controls.Add(btnYMenosEsfera);
        this.Controls.Add(btnYMasEsfera);
        this.Controls.Add(btnZMenosEsfera);
        this.Controls.Add(btnZMasEsfera);
        this.Controls.Add(btnXMenos);
        this.Controls.Add(btnXMas);
        this.Controls.Add(btnYMas);
        this.Controls.Add(btnYMenos);
        this.Controls.Add(btnZMas);
        this.Controls.Add(btnZMenos);
        this.Controls.Add(btnAumentarParalelos);
        this.Controls.Add(btnDisminuirParalelos);

    }


    private void Form1_Paint(object? sender, PaintEventArgs e)
    {
       Graphics g = e.Graphics;
        Pen pen = new Pen(Color.Red, 2);

    
        int desplazamientoZ_X = posCuboZ / 2;
        int desplazamientoZ_Y = -(posCuboZ / 2);

        int origenX = 100 + posCuboX + desplazamientoZ_X;
        int origenY = 100 + posCuboY + desplazamientoZ_Y;

        Point[] caraFrontal = {
            new Point(origenX, origenY),
            new Point(origenX + 100, origenY),
            new Point(origenX + 100, origenY + 100),
            new Point(origenX, origenY + 100)
        };

        Point[] caraTrasera = {
            new Point(origenX + 50, origenY - 50),
            new Point(origenX + 150, origenY - 50),
            new Point(origenX + 150, origenY + 50),
            new Point(origenX + 50, origenY + 50)
        };

        // Dibujamos las caras
        g.DrawPolygon(pen, caraFrontal);
        g.DrawPolygon(pen, caraTrasera);

        // Dibujamos las líneas de interseccion
        g.DrawLine(pen, caraFrontal[0], caraTrasera[0]);
        g.DrawLine(pen, caraFrontal[1], caraTrasera[1]);
        g.DrawLine(pen, caraFrontal[2], caraTrasera[2]);
        g.DrawLine(pen, caraFrontal[3], caraTrasera[3]);


        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        Pen penEsfera = new Pen(Color.Blue, 1); 

        int radio = 80;
        int centroX = 350 + posEsferaX; 
        int centroY = 200 + posEsferaY;

        

        PointF[,] puntos2D = new PointF[paralelos + 1, meridianos + 1];

        for (int i = 0; i <= paralelos; i++)
        {
            double latitud = Math.PI * i / paralelos; 

            for (int j = 0; j <= meridianos; j++)
            {
                double longitud = 2 * Math.PI * j / meridianos; 

                double x3D = radio * Math.Sin(latitud) * Math.Cos(longitud);
                double y3D = radio * Math.Cos(latitud); 
                double z3D = radio * Math.Sin(latitud) * Math.Sin(longitud);

                double movMundoX = posEsferaZ / 2.0;
                double movMundoY = -(posEsferaZ / 2.0);

                double factorPerspectiva = 250.0 / (250.0 + z3D); 

                float screenX = (float)(centroX + movMundoX + (x3D * factorPerspectiva));
                float screenY = (float)(centroY + movMundoY + (y3D * factorPerspectiva));

                puntos2D[i, j] = new PointF(screenX, screenY);
            }
        }

        for (int i = 0; i < paralelos; i++)
        {
            for (int j = 0; j < meridianos; j++)
            {
                g.DrawLine(penEsfera, puntos2D[i, j], puntos2D[i + 1, j]);
                g.DrawLine(penEsfera, puntos2D[i, j], puntos2D[i, j + 1]);
            }
        }



        pen.Dispose();
        penEsfera.Dispose();

    }
}
