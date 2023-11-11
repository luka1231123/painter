using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter;

internal class ExtraMethods
{
    public vec3 mouseLoc=new vec3(0,0,0);
    public double aspectRatio = 16.0 / 9.0;

    public bool ikp(Keyboard.Key key)
    {

        return Keyboard.IsKeyPressed(key);


    }
    public void updateMouseLoc(){
        mouseLoc.x = Mouse.GetPosition().X;
        mouseLoc.y = Mouse.GetPosition().Y;


    }
    public bool imp()
    {
        return Mouse.IsButtonPressed(Mouse.Button.Left);
    }
    public bool impR()
    {
        return Mouse.IsButtonPressed(Mouse.Button.Right);
    }

}