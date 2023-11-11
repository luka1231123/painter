using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Painter;

public class Window
{
    ExtraMethods exm = new ExtraMethods();
    public uint xWidth { get; set; } = 1024;
    public uint yHeight { get; set; } 
    public string Title { get; set; } = "Ray";

    static vec3[,] screenArray = new vec3[1024,576];
    public Image image { get; set; }
    public Texture texture { get; set; }
    public Sprite sprite { get; set; }
    public RenderWindow win { get; set; }
    public Window() {
        yHeight = (uint)(xWidth / exm.aspectRatio);
        image = new Image(xWidth, yHeight);
        texture = new Texture(image);
        sprite = new Sprite(texture);
        win = new RenderWindow(new SFML.Window.VideoMode(xWidth, yHeight), Title);
        win.Closed += (sender, e) => win.Close();
        
        for(int i=0;i<1024;i++){
            for(int j=0;j<576;j++){
                screenArray[i,j]=new vec3(0,0,0);
                //if(i%18==0 || j%18==0){
                //  screenArray[i,j]=new vec3(1,0,0);
                //}
            }
        }
    }
    //use setPixel alternative to aleter ScreenArray;
    public void SetPixelArray(int x, int y,vec3 color)
    {
        screenArray[x,y]=color;

    }
    public void SetPixel(uint x, uint y,vec3 color)
    {
        double cx = color.x * 255.999;
        double cy = color.y * 255.999;
        double cz = color.z * 255.999;
        Color clr = new Color((byte)(cx), (byte)(cy), (byte)(cz));
        image.SetPixel(x,y,clr);
    }
    public void Refresh()
    {
        win.DispatchEvents();
        win.Clear();
        image= new Image(xWidth, yHeight);

        
    }
    public void Draw()
    {
        for(int i=0;i<1024;i++){
            for(int j=0;j<576;j++){
                SetPixel((uint)(i), (uint)(j), screenArray[i,j]);
            }
        }
        texture = new Texture(image);
        sprite = new Sprite(texture);
        win.Draw(sprite);
        win.Display();
    }
    public double winPositionX(){
        return win.Position.X;
    }
    public double winPositionY(){
        return win.Position.Y;
    }
    public bool windOpen()
    {
        bool bl = true;
        bl = win.IsOpen;
        return bl;
    }

}