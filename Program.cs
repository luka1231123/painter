﻿using System;
using System.Numerics;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Painter.ExtraMethods;
using System.IO;

namespace Painter;
public class Program
{
    static vec3[,] vec3array = new vec3[32,32];
    
    static Window wnd = new Window();
    static vec3 color = new vec3 (0, 0, 0);
    static Random rnd = new Random();
    static ExtraMethods exm = new ExtraMethods();
    static double mx = 0;
    static double my = 0; 
    static string pvath;
    static void init()
    {
        pvath = Console.ReadLine();
        for (int i = 0;i<32;i++){
            for (int j = 0;j<32;j++){
                vec3array[i,j] = new vec3(0,0,0);
            }
        }
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {

                paintTile(i,j,vec3array[i,j]);
            }
        }
    }
    static void Main()
    {
        init();
        
        //main loop
        while (wnd.windOpen())
        {
            wnd.Refresh();


            exm.updateMouseLoc();
            //events here
            if(exm.ikp(Keyboard.Key.Q)){
                color=new vec3(0,0,0);
            }
            if(exm.ikp(Keyboard.Key.W)){
                color=new vec3(1,0,0);
            }
            if(exm.ikp(Keyboard.Key.E)){
                color=new vec3(0,1,0);
            }
            if(exm.ikp(Keyboard.Key.R)){
                color=new vec3(0,0,1);
            }
            if(exm.ikp(Keyboard.Key.T)){
                color=new vec3(1,0,1);
            }
            if(exm.ikp(Keyboard.Key.X)){
                init();
            }
            if (exm.ikp(Keyboard.Key.C)) {
                SaveToFile(pvath,"wallah");//this a change
            }
            if(exm.imp()){
                mx=exm.mouseLoc.x;
                my=exm.mouseLoc.y;
                Console.WriteLine(my-wnd.winPositionY());
                if(mx-wnd.winPositionX()>448 && mx-wnd.winPositionX()<1024 && my-wnd.winPositionY()>38 && my-wnd.winPositionY()<612){
                    paintTile(TileFinderX(mx-wnd.winPositionX()),TileFinderY(my-wnd.winPositionY()),color);
                }
            }



            wnd.Draw();
        }
        
    }
    static int TileFinderX(double xd)
    {
        int x=Convert.ToInt32(xd);        
        x=x-448;
        x=(int)x/18;

        return x;
        
    }
    static int TileFinderY(double yd)
    {
        int y=Convert.ToInt32(yd);        
        y=y-38;
        y=(int)y/18;

        return y;

        
    }
    static void SaveToFile(string path, string name)
    {
        Console.WriteLine("ss");
        if (File.Exists(name))
        {
            File.Delete(name);
        }

        StreamWriter sw = new StreamWriter($"{path}{name}");

        for (int i = 0;i<32;i++)
        {
            for(int j=0;j<32; j++)
            {
                sw.WriteLine($"{vec3array[i,j].x} {vec3array[i,j].y} {vec3array[i,j].z}");
                Console.WriteLine(vec3array[i,j].x);
            }
            sw.WriteLine("***");
        }
        
    }
    static void paintTile(int tileX, int tileY, vec3 colorc)
    {
        vec3array[tileX,tileY]= colorc;
        for(int i=0; i<18; i++){
            for(int j=0;j<18;j++){
                wnd.SetPixelArray((i+(tileX*18)+448), (j+(tileY*18)), colorc);
                if(j==17 || i==17 || i==0 || j==0){
                    wnd.SetPixelArray((i+(tileX*18)+448), (j+(tileY*18)), new vec3(1,1,1));
                }
            }
        }
    }

}