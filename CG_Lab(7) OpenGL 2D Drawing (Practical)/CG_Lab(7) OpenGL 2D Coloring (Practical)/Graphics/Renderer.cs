using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        uint IndexBufferID;

        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");

            Gl.glClearColor(1, 1, 1, 1); // خلفية

            float[] verts = { 

                //——————left ears———
                -0.757f,0.941f,0.0f,      //0
                0.3f,0.6f,0.9f,
                -0.735f,0.647f,0.0f,      //1
                0.3f,0.6f,0.9f,
                -0.503f,0.716f,0.0f,      //2
                0.3f,0.6f,0.9f,
                 //——————right ears———
                 0.164f,0.922f,0.0f,      //3
                 0.3f,0.6f,0.9f,
                 0.164f,0.627f,0.0f,     //4
                 0.3f,0.6f,0.9f,
                -0.079f,0.706f,0.0f,     //5
                0.3f,0.6f,0.9f,
                        //————head———
                -0.291f,0.784f,0.0f,     //6
                0.4f,0.4f,0.12f,
                -0.503f,0.716f,0.0f,      //7
                 0.4f,0.4f,0.12f,
                -0.735f,0.647f,0.0f,      //8
                 0.4f,0.4f,0.12f,
                -0.725f,0.431f,0.0f,      //9
                 0.4f,0.4f,0.12f,
                -0.598f,0.275f,0.0f,      //10
                 0.4f,0.4f,0.12f,
                -0.291f,0.137f,0.0f,      //11
                 0.4f,0.4f,0.12f,
                 0.079f,0.304f,0.0f,      //12
                  0.4f,0.4f,0.12f,
                 0.185f,0.441f,0.0f,      //13
                  0.4f,0.4f,0.12f,
                 0.164f,0.627f,0.0f,      //14
                  0.4f,0.4f,0.12f,
                -0.079f,0.706f,0.0f,      //15
                 0.4f,0.4f,0.12f,
                -0.291f,0.784f,0.0f,      //16
                 0.4f,0.4f,0.12f,
                        //—————eye1————
                -0.122f,0.363f,0.0f,      //17
                0,0,0,
                0.005f,0.363f,0.0f,      //18
                0,0,0,
                        //=======eye2——
                -0.556f,0.363f,0.0f,         //19
                0,0,0,
                -0.418f,0.363f,0.0f,         //20
                0,0,0,
                //nose
                -0.291f,0.137f,0.0f,  //21
                    0,0,0,

                

                    //——body———left_arm————
                -0.598f,0.275f,0.0f,   //22
                0.233f, 0.145f, 0.74f,
                -0.481f,-0.873f,0.0f,   //23
                 0.233f, 0.145f, 0.74f,
                -0.471f,-0.157f, 0.0f,    //24
                 0.233f, 0.145f, 0.74f,
                
                //—————upper_triangle_btn(left&right_arm)————
                -0.598f,0.275f,0.0f,   //25
                 0.533f, 0.545f, 0.54f,
                -0.291f,0.137f,0.0f,  //26
                 0.533f, 0.545f, 0.54f,
                -0.471f,-0.157f,0.0f,    //27
                 0.533f, 0.545f, 0.54f,
                //—————lower_triangle_btn(left&right_arm)————
                -0.471f,-0.157f,0.0f,     //28
                 0.333f, 0.345f, 0.34f,
                -0.291f,-0.765f,0.0f,    //29
                 0.333f, 0.345f, 0.34f,
                -0.481f,-0.873f,0.0f,   //30
                 0.333f, 0.345f, 0.34f,
                

                //—————right_arm—————
                -0.291f,0.137f,0.0f,  //31
                 0.233f, 0.145f, 0.74f,
                -0.291f,-0.765f,0.0f,   //32
                 0.233f, 0.145f, 0.74f,
                -0.471f,-0.157f,0.0f,     //33
                 0.233f, 0.145f, 0.74f,
                

                //——————-next————
                -0.291f,0.137f,0.0f,  //34
                1,0,0,
                -0.122f,-0.167f,0.0f,       //35
                1,0,0,
                -0.291f,-0.765f,0.0f,    //36
                1,0,0,
                

                //—————————————
                -0.291f,0.137f,0.0f, //37
                1,0,0,
                0.016f,0.265f,0.0f,       //38
                1,1,0,
                -0.122f,-0.167f,0.0f,       //39
                1,0,1,
                //----------------
                -0.122f,-0.167f,0.0f,       //40
                1,0,0.5F,
                -0.291f,-0.765f,0.0f,    //41
                1,0.5f,0,
                -0.122f,-0.873f,0.0f,    //42
                1,0.5f,0,
                //————————
                -0.122f,-0.167f,0.0f,       //43
                0.1f,0.2f,0.3f,
                0.016f,0.265f, 0.0f,      //44
                0.1f,0.2f,0.3f,
                -0.122f,-0.873f,0.0f,    //45
                0.1f,0.2f,0.3f,
                //———-
                -0.122f,-0.873f, 0.0f,   //46
                0.2f,0.4f,0.6f,
                0.016f,0.265f, 0.0f,      //47
               0.2f,0.4f,0.6f,
                0.344f,-0.147f,0.0f,    //48
                0.2f,0.4f,0.6f,
                //——————
                0.333f,-0.696f,0.0f,    //49
                1,1,0,
                -0.225f,-0.883f,0.0f,    //50
                1,0,1,
                0.185f,-0.892f,0.0f,   //51
                1,1,0,
                //———————
                0.185f,-0.892f,0.0f,       //52
                1,0.5f,0,
                0.333f,-0.696f,0.0f,    //53
                1,0,0,
                0.693f,-0.873f,0.0f,        //54
                1,0,0.5f,
                //—————
                0.693f,-0.873f,0.0f,        //55
                1,0,0,
                0.333f,-0.696f ,0.0f,   //56
                0,1,1,
                0.926f,-0.882f  ,0.0f,      //57
                1,1,0,
                //——————
                0.926f,-0.882f ,0.0f,       //58
                1,0,1,
                0.714f,-0.725f , 0.0f,        //59
                1,0,1,
                0.746f,-0.814f  ,0.0f,  //60
                1,0,0,
                //————————
                -0.481f,-0.873f ,0.0f,    //61
                0,0,0,
                -0.291f,-0.765f  ,0.0f,    //62
                0,0,0,
                -0.122f,-0.873f  ,0.0f,    //63
                0,0,0,
                //---------------
                -0.122f,-0.873f,0.0f,
                0,0,0,
                0.33f,-0.696f,0.0f,
                0,0,0,
                0.344f,-0.147f,0.0f,
                0,0,0,
            };

            vertexBufferID = GPU.GenerateBuffer(verts);

            // Array of indices
            ushort[] indices = { 0, 1, 2, 1, 2, 3 };
            IndexBufferID = GPU.GenerateElementBuffer(indices);

        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();

            Gl.glEnableVertexAttribArray(0);
            Gl.glEnableVertexAttribArray(2);

            //// Positions of points
            //Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 0, IntPtr.Zero);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);

            //// Color 
            Gl.glVertexAttribPointer(2, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float) * 3));


          Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 3, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 6, 11);
            Gl.glLineWidth(5);
            Gl.glDrawArrays(Gl.GL_LINES, 17, 2);
            
            Gl.glDrawArrays(Gl.GL_LINES, 19, 2);
            
            
            Gl.glPointSize(15);
            Gl.glDrawArrays(Gl.GL_POINTS, 21, 1);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 22, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 25, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 28, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 31, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 34, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 37, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 37, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 40, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 43, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 46, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 49, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 52, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 55, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 58, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 61, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 64, 3);

            // Gl.glDrawElements(Gl.GL_TRIANGLES, 6, Gl.GL_UNSIGNED_SHORT, IntPtr.Zero);


            Gl.glDisableVertexAttribArray(2);
            Gl.glDisableVertexAttribArray(0);
        }

        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
