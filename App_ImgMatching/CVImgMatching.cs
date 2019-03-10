using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV.Structure;

namespace MyCode
{
    class CVImgMatching
    {
        private List<Emgu.CV.Image<Bgr, byte>> m_ListTemplateImg = new List<Emgu.CV.Image<Bgr, byte>>();
        private List<string> m_ListTemplatePath = new List<string>();
        private List<Emgu.CV.Image<Gray, float>> m_ListImgResult = new List<Emgu.CV.Image<Gray, float>>();
        private int m_CurrentResultIndex = -1;
        private double m_ScoreThreshold = 0.90;
        public void SetScoreThreshold(double f_ScoreThreshold)
        {
            m_ScoreThreshold = f_ScoreThreshold;
        }
        private Emgu.CV.CvEnum.TemplateMatchingType m_TemplateMatchingType = Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed;
        public void SetTemplateMatchingType(Emgu.CV.CvEnum.TemplateMatchingType f_TemplateMatchingType)
        {
            m_TemplateMatchingType = f_TemplateMatchingType;
        }

        public CVImgMatching(Emgu.CV.Image<Bgr, byte> f_TemplateImg, double f_ScoreThreshold = 0.90)
        {
            m_ListTemplateImg.Add(f_TemplateImg);
            m_ScoreThreshold = f_ScoreThreshold;
        }
        

        public bool DoMatchByFile(Emgu.CV.Image<Bgr,byte> f_SrcImg, bool f_Debug = false)
        {
            //double t_MinScore = 0, t_MaxScore = 0;
            //Point t_MinScorePoint = Point.Empty;
            //Point t_MaxScorePoint = Point.Empty;
            for(int i = 0; i< m_ListTemplateImg.Count; i++)
            {
                m_ListImgResult.Add(f_SrcImg.MatchTemplate(m_ListTemplateImg[i], m_TemplateMatchingType));
            }
            return true;
            /*
            t_MinScore = t_MaxScore = 0;
            t_MinScorePoint = t_MaxScorePoint = Point.Empty;
            Emgu.CV.CvInvoke.MinMaxLoc(t_Result, ref t_MinScore, ref t_MaxScore, ref t_MinScorePoint, ref t_MaxScorePoint);
            if (t_MaxScore >= m_ScoreThreshold)
            {
                t_Result.Dispose();
                Rectangle t_TargetRect = new Rectangle(t_MaxScorePoint, new Size(m_TemplateImg.Width, m_TemplateImg.Height));
                return t_TargetRect;
            }
            if (f_Debug == true)
            {
                Emgu.CV.CvInvoke.Rectangle(m_SrcImg, new Rectangle(t_MaxScorePoint, new Size(m_TemplateImg.Width, m_TemplateImg.Height)), new MCvScalar(0, 0, 255));
                Emgu.CV.CvInvoke.Imshow("Temp", m_SrcImg);
                Emgu.CV.CvInvoke.WaitKey(0);
                Emgu.CV.CvInvoke.DestroyAllWindows();
            }
            t_Result.Dispose();
            return Rectangle.Empty;
            */
        }
        public Rectangle GetRectangle()
        {
            return Rectangle.Empty;
        }
        public Point GetCentrePoint()
        {
            return Point.Empty;
        }

    }
}

        //private List<string> m_TemplateFileFullPath;
        //private List<Emgu.CV.Image<Bgr, byte>> m_ImageTemplate;



        //private bool CheckTempleteDir(string f_DirFullPath)
        //{
        //    LogIt($"CheckTempleteDir: CheckTempleteDir({f_DirFullPath}) ++");
        //    bool t_IsOK = false;
        //    if (System.IO.Directory.Exists(f_DirFullPath) == true)
        //    {
        //        m_TemplateFileFullPath.AddRange(System.IO.Directory.GetFiles(f_DirFullPath, "*.png"));
        //        m_TemplateFileFullPath.AddRange(System.IO.Directory.GetFiles(f_DirFullPath, "*.jpg"));
        //        if (m_TemplateFileFullPath.Count > 0)
        //        {
        //            t_IsOK = true;
        //        }
        //    }
        //    LogIt($"CheckTempleteDir: CheckTempleteDir({f_DirFullPath}) --");
        //    return t_IsOK;
        //}
        //private bool CheckTempleteFile(string f_FileFullPath)
        //{
        //    LogIt($"CheckTempleteDir: CheckTempleteFile({f_FileFullPath}) ++");
        //    bool t_IsOK = false;
        //    if (System.IO.File.Exists(f_FileFullPath) == false)
        //    {
        //        m_TemplateFileFullPath.Add(f_FileFullPath);
        //        t_IsOK = true;
        //    }
        //    LogIt($"CheckTempleteDir: CheckTempleteFile({f_FileFullPath}) --");
        //    return t_IsOK;
        //}
        //public bool LoadTemplete(string f_DirOrFileFullPath)
        //{
        //    LogIt($"CheckTempleteDir: LoadTemplete({f_DirOrFileFullPath}) ++");
        //    bool t_IsOK = false;
        //    try
        //    {
        //        System.IO.FileAttributes t_FileAttributes = System.IO.File.GetAttributes(f_DirOrFileFullPath);
        //        if (t_FileAttributes.HasFlag(System.IO.FileAttributes.Directory) == true)
        //        {
        //            t_IsOK = CheckTempleteDir(f_DirOrFileFullPath);
        //        }
        //        else
        //        {
        //            t_IsOK = CheckTempleteFile(f_DirOrFileFullPath);
        //        }
        //        if (t_IsOK == true)
        //        {
        //            for (int i = 0; i < m_TemplateFileFullPath.Count; i++)
        //            {
        //                Emgu.CV.Image<Bgr, byte> t_Image = new Emgu.CV.Image<Bgr, byte>(m_TemplateFileFullPath[i]);
        //                m_ImageTemplate.Add(t_Image);
        //            }
        //        }
        //    }
        //    catch(Exception Ex)
        //    {
        //        t_IsOK = false;
        //    }
        //    LogIt($"CheckTempleteDir: LoadTemplete({f_DirOrFileFullPath}) -- Result={t_IsOK.ToString()}");
        //    return t_IsOK;
        //}
        //public Rectangle DoImageMatching(Emgu.CV.Image<Bgr, byte> f_SourceImage, bool f_Debug = false)
        //{
        //    LogIt($"[DoImageMatching]: ++");

        //    double t_MinScore = 0, t_MaxScore = 0;
        //    Point t_MinScorePoint = Point.Empty;
        //    Point t_MaxScorePoint = Point.Empty;

        //    for (int i = 0; i < m_ImageTemplate.Count; i++)
        //    {
        //        Emgu.CV.Image<Gray, float> t_Result = f_SourceImage.MatchTemplate(m_ImageTemplate[i], Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
        //        t_MinScore = t_MaxScore = 0;
        //        t_MinScorePoint = t_MaxScorePoint = Point.Empty;
        //        Emgu.CV.CvInvoke.MinMaxLoc(t_Result, ref t_MinScore, ref t_MaxScore, ref t_MinScorePoint, ref t_MaxScorePoint);
        //        if (t_MaxScore >= m_ScoreLimit)
        //        {
        //            ImageGeneral.DisposeImage(t_Result);
        //            Rectangle t_TargetRect = new Rectangle(t_MaxScorePoint, new Size(m_ImageTemplate[i].Width, m_ImageTemplate[i].Height));
        //            LogIt($"[DoImageMatching]: -- Result=Found; Max Socre: {t_MaxScore}; Pos:({t_TargetRect.X},{t_TargetRect.Y}); Size:({t_TargetRect.Width},{t_TargetRect.Height})");
        //            return t_TargetRect;
        //        }
        //        if (f_Debug == true)
        //        {
        //            Emgu.CV.CvInvoke.Rectangle(f_SourceImage, new Rectangle(t_MaxScorePoint, new Size(m_ImageTemplate[i].Width, m_ImageTemplate[i].Height)), new MCvScalar(0, 0, 255));
        //            Emgu.CV.CvInvoke.Imshow("Temp", f_SourceImage);
        //            Emgu.CV.CvInvoke.WaitKey(0);
        //            Emgu.CV.CvInvoke.DestroyAllWindows();
        //        }
        //        ImageGeneral.DisposeImage(t_Result);
        //    }
        //    LogIt($"[DoImageMatching]: -- Result=Failed; Max Socre: {t_MaxScore}");
        //    return Rectangle.Empty;
        //}

        //void LogIt(String msg)
        //{
        //    System.Diagnostics.Trace.WriteLine(string.Format("[ImageMatching] [Label_{0}] [Info={1}] [{2}]: {3}", iosDevice._this.GetLabel(), m_Info, DateTime.Now.ToString("MM-ddTHH:mm:ss.fff"), msg));
        //}

        //public void Dispose()
        //{
        //    m_TemplateFileFullPath.Clear();
        //    m_TemplateFileFullPath = null;
        //    m_ImageTemplate.Clear();
        //    m_ImageTemplate = null;
        //}
