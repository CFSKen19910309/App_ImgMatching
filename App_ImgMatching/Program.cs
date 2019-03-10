using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using MyCode;
namespace App_ImgMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Emgu.CV.Image<Bgr, byte> t_SrcImg = new Emgu.CV.Image<Bgr, byte>("Src.png");///.SmoothBlur(5,5);//.Resize(2.0, Emgu.CV.CvEnum.Inter.Cubic );
            Emgu.CV.Image<Bgr, byte> t_TemplateImg = new Emgu.CV.Image<Bgr, byte>("Template.png");///.SmoothBlur(5, 5);//.Resize(2.0, Emgu.CV.CvEnum.Inter.Cubic);
            Emgu.CV.CvInvoke.NamedWindow("Src", Emgu.CV.CvEnum.NamedWindowType.Normal);
            Emgu.CV.CvInvoke.Imshow("Src", t_SrcImg);
            Emgu.CV.CvInvoke.NamedWindow("Template", Emgu.CV.CvEnum.NamedWindowType.Normal);
            Emgu.CV.CvInvoke.Imshow("Template", t_TemplateImg);
            CVImgMatching t_CVImgMatching = new CVImgMatching(t_SrcImg, t_TemplateImg);

            Emgu.CV.Image<Gray, float> t_Result = t_CVImgMatching.DoMatchByFile();
            Emgu.CV.CvInvoke.NamedWindow("0", Emgu.CV.CvEnum.NamedWindowType.Normal);
            Emgu.CV.CvInvoke.NamedWindow("AA", Emgu.CV.CvEnum.NamedWindowType.Normal);

            double t_MinScore = 0;
            double t_MaxScore = 0;
            Point t_MinScorePoint = Point.Empty;
            Point t_MaxScorePoint = Point.Empty;

            Emgu.CV.CvInvoke.MinMaxLoc(t_Result, ref t_MinScore, ref t_MaxScore, ref t_MinScorePoint, ref t_MaxScorePoint);
            if (t_MaxScore >= 0.5)
            {
                Rectangle t_TargetRect = new Rectangle(t_MaxScorePoint, new Size(t_TemplateImg.Width, t_TemplateImg.Height));
                Emgu.CV.CvInvoke.Rectangle(t_SrcImg, t_TargetRect, new MCvScalar(255, 0, 0), 2);
                Emgu.CV.CvInvoke.Imshow("Src", t_SrcImg);
                //Emgu.CV.CvInvoke.Rectangle(t_Result, t_TargetRect, new MCvScalar(255, 0, 0), 2);
                //Emgu.CV.CvInvoke.Imshow("AA", t_Result);
            }

            Emgu.CV.CvInvoke.Imshow("AA", t_Result);
            Emgu.CV.CvInvoke.WaitKey(0);
        }
    }
}
