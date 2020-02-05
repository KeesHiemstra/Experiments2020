using Graph1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graph1.ViewModels
{
  class VisualTemperatures
  {

    private readonly List<DailyReport> Daily;
    private readonly Canvas GraphCanvas;

    private decimal? MinTemp;
    private decimal? MaxTemp;
    private decimal MinGraphTemp;
    private decimal MaxGraphTemp;

    private double AxisWidthOffset = 0;
    private double AxisHeight = 200;
    private double AxisWidth = 400;

    private double Baseline = 100;
    private double ScatterTemp;
    private double ScatterDay;


    public VisualTemperatures(List<DailyReport> dailyReports)
    {

      Daily = dailyReports;
      GraphCanvas = new Canvas();

    }

    public Canvas CreateTemperatureGraphic()
    {

      DetermineValues();
      DrawAxis();
      DrawScale(Daily.Count);
      DrawTemperatures();

      return GraphCanvas;

    }

    private void DetermineValues()
    {

      MinTemp = Daily.Min(x => x.TN);
      if (MinTemp > 0) { MinTemp = 0; }
      MaxTemp = Daily.Max(x => x.TX);
      if (MaxTemp < 0) { MaxTemp = 0; }

      MinGraphTemp = (Math.Floor(MinTemp.Value / 5) * 5);
      MaxGraphTemp = (Math.Ceiling(MaxTemp.Value / 5) * 5);

      ScatterTemp = AxisHeight / (double)(Math.Abs(MaxGraphTemp) + Math.Abs(MinGraphTemp));
      Baseline = (double)(Math.Abs(MaxGraphTemp)) * ScatterTemp;

    }

    private void DrawAxis()
    {

      AxisWidth -= AxisWidthOffset;

      //X axis
      Line line = new Line()
      {
        X1 = AxisWidthOffset,
        Y1 = Baseline,
        X2 = AxisWidthOffset + AxisWidth,
        Y2 = Baseline,
        StrokeThickness = 1.0,
        Stroke = Brushes.Black
      };
      GraphCanvas.Children.Add(line);

      //Y axis
      line = new Line()
      {
        X1 = 0,
        Y1 = 0,
        X2 = 0,
        Y2 = 200,
        StrokeThickness = 1.0,
        Stroke = Brushes.Black
      };
      GraphCanvas.Children.Add(line);

    }

    private void DrawScale(int numberOfDays)  
    {

      ScatterDay = (AxisWidth - AxisWidthOffset) / numberOfDays;
      Line line;
      for (int i = 1; i < numberOfDays; i++)
      {
        if (Daily[i].Date.DayOfWeek == DayOfWeek.Monday)
        {
          line = new Line()
          {
            X1 = ScatterDay * i,
            Y1 = 0,
            X2 = ScatterDay * i,
            Y2 = AxisHeight,
            StrokeThickness = 0.5,
            Stroke = Brushes.Gray
          };
          GraphCanvas.Children.Add(line);
        }

        if (Daily[i].Date.Day == 1)
        {
          line = new Line()
          {
            X1 = ScatterDay * i,
            Y1 = 0,
            X2 = ScatterDay * i,
            Y2 = AxisHeight,
            StrokeThickness = 0.5,
            Stroke = Brushes.DarkGray
          };
          GraphCanvas.Children.Add(line);
        }

        line = new Line()
        {
          X1 = ScatterDay * i,
          Y1 = Baseline - 2.5,
          X2 = ScatterDay * i,
          Y2 = Baseline + 2.5,
          StrokeThickness = 1.0,
          Stroke = Brushes.Black
        };
        GraphCanvas.Children.Add(line);
      }

      for (decimal i = MinGraphTemp; i <= MaxGraphTemp; i += 5)
      {
        line = new Line()
        {
          X1 = AxisWidthOffset,
          Y1 = TempToPoint(i),
          X2 = AxisWidth,
          Y2 = TempToPoint(i),
          StrokeThickness = 0.5,
          Stroke = Brushes.Gray
        };
        GraphCanvas.Children.Add(line);
      }

      for (decimal i = MinGraphTemp; i <= MaxGraphTemp; i++)
      {
        line = new Line()
        {
          X1 = AxisWidthOffset,
          Y1 = TempToPoint(i),
          X2 = AxisWidthOffset + 2.5,
          Y2 = TempToPoint(i),
          StrokeThickness = 1.0,
          Stroke = Brushes.Black
        };
        GraphCanvas.Children.Add(line);

      }

    }

    private double TempToPoint(decimal Temp)
    {
      return Baseline - ((double)Temp * ScatterTemp);
    }

    private void DrawTemperatures()
    {

      Line line;
      double LastDay = AxisWidthOffset;
      double LastTemp = TempToPoint(Daily[0].TN.Value);

      for (int i = 1; i < Daily.Count; i++)
      {
        line = new Line()
        {
          X1 = LastDay,
          Y1 = LastTemp,
          X2 = AxisWidthOffset + i * ScatterDay,
          Y2 = TempToPoint(Daily[i].TN.Value),
          StrokeThickness = 0.5,
          Stroke = Brushes.Blue
        };

        LastDay = line.X2;
        LastTemp = line.Y2;

        GraphCanvas.Children.Add(line);
      }

      LastDay = AxisWidthOffset;
      LastTemp = TempToPoint(Daily[0].TG.Value);

      for (int i = 1; i < Daily.Count; i++)
      {
        line = new Line()
        {
          X1 = LastDay,
          Y1 = LastTemp,
          X2 = AxisWidthOffset + i * ScatterDay,
          Y2 = TempToPoint(Daily[i].TG.Value),
          StrokeThickness = 0.5,
          Stroke = Brushes.Green
        };

        LastDay = line.X2;
        LastTemp = line.Y2;

        GraphCanvas.Children.Add(line);
      }

      LastDay = AxisWidthOffset;
      LastTemp = TempToPoint(Daily[0].TX.Value);

      for (int i = 1; i < Daily.Count; i++)
      {
        line = new Line()
        {
          X1 = LastDay,
          Y1 = LastTemp,
          X2 = AxisWidthOffset + i * ScatterDay,
          Y2 = TempToPoint(Daily[i].TX.Value),
          StrokeThickness = 0.5,
          Stroke = Brushes.Red
        };

        LastDay = line.X2;
        LastTemp = line.Y2;

        GraphCanvas.Children.Add(line);
      }

    }
  }
}
