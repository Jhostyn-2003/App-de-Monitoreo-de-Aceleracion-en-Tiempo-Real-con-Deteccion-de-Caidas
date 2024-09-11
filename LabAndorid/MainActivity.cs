using Android.App;
using Android.OS;
using Android.Widget;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;
using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Essentials;

namespace LabAndorid
{
    [Activity(Label = "EdgeComputingApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private PlotView plotView;
        private LineSeries lineSeries;
        private List<DataPoint> dataPoints;
        private DateTime startTime;
        private bool isAccelerometerStarted = false;
        private const int MaxDataPoints = 20;
        private Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            plotView = FindViewById<PlotView>(Resource.Id.plotView);
            dataPoints = new List<DataPoint>();
            startTime = DateTime.Now;

            InitializePlot();

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

            StartAccelerometer();
        }

        private void InitializePlot()
        {
            var plotModel = new PlotModel { Title = "Evolución de la Aceleración" };

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "hh:mm:ss",
                Title = "Tiempo",
                IntervalLength = 60,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Aceleración",
                Minimum = 0,
                Maximum = 4
            });

            lineSeries = new LineSeries { MarkerType = MarkerType.Circle };
            plotModel.Series.Add(lineSeries);

            plotView.Model = plotModel;
        }

        private void StartAccelerometer()
        {
            if (!isAccelerometerStarted)
            {
                Accelerometer.Start(SensorSpeed.UI);
                isAccelerometerStarted = true;
            }
        }

        private void StopAccelerometer()
        {
            if (isAccelerometerStarted)
            {
                Accelerometer.Stop();
                isAccelerometerStarted = false;
            }
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            double acceleration = Math.Sqrt(data.Acceleration.X * data.Acceleration.X +
                                            data.Acceleration.Y * data.Acceleration.Y +
                                            data.Acceleration.Z * data.Acceleration.Z);

            RunOnUiThread(() =>
            {
                var currentTime = DateTimeAxis.ToDouble(DateTime.Now);
                dataPoints.Add(new DataPoint(currentTime, acceleration));

                // Mantener solo los últimos 20 puntos
                if (dataPoints.Count > MaxDataPoints)
                {
                    dataPoints.RemoveAt(0);
                }

                lineSeries.Points.Clear();
                lineSeries.Points.AddRange(dataPoints);

                plotView.InvalidatePlot(true);

                if (acceleration > 2.5)
                {
                    Toast.MakeText(this, "¡Posible caída detectada!", ToastLength.Long).Show();
                }
            });

            // Detener el temporizador si ya está en funcionamiento y reiniciarlo para la pausa
            if (timer != null)
            {
                timer.Dispose();
            }
            // Crear un nuevo temporizador para controlar la velocidad de actualización (500 ms en este caso)
            timer = new Timer(state =>
            {
                // No hacer nada, solo para introducir una pausa entre actualizaciones
            }, null, 500, Timeout.Infinite);
        }

        protected override void OnPause()
        {
            base.OnPause();
            StopAccelerometer();
            timer?.Dispose();
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartAccelerometer();
        }
    }
}
