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

    private double AxisHeightLocation = 100;
    private double AxisWidthOffset = 0;
    private double AxisHeight = 200;
    private double AxisWidth = 400;


    public VisualTemperatures(List<DailyReport> dailyReports)
    {

      Daily = dailyReports;
      GraphCanvas = new Canvas();

    }

    public Canvas CreateTemperatureGraphic()
    {

      DetermineTemperatures();
      CreateAxis();

      return GraphCanvas;

    }

    private void DetermineTemperatures()
    {

      MinTemp = Daily.Min(x => x.TN);
      if (MinTemp > 0) { MinTemp = 0; }
      MaxTemp = Daily.Max(x => x.TX);
      if (MaxTemp < 0) { MaxTemp = 0; }

      MinGraphTemp = (Math.Floor(MinTemp.Value / 5) * 5);
      MaxGraphTemp = (Math.Floor(MaxTemp.Value / 5) * 5) + 5;

    }

    private void CreateAxis()
    {

      AxisWidth -= AxisWidthOffset;
      AxisHeightLocation = 100;

      //X axis
      Line line = new Line()
      {
        X1 = AxisWidthOffset,
        Y1 = AxisHeightLocation,
        X2 = AxisWidthOffset + AxisWidth,
        Y2 = AxisHeightLocation,
        StrokeThickness = 0.5,
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
        StrokeThickness = 0.5,
        Stroke = Brushes.Black
      };
      GraphCanvas.Children.Add(line);

      //for (int i = 1; i < numberOfDays; i++)
      //{
      //  line = new Line()
      //  {
      //    X1 = DayWidth * i,
      //    Y1 = 95,
      //    X2 = DayWidth * i,
      //    Y2 = 105,
      //    StrokeThickness = 0.5,
      //    Stroke = Brushes.Black
      //  };
      //  GraphCanvas.Children.Add(line);
      //}

    }

  }
}
