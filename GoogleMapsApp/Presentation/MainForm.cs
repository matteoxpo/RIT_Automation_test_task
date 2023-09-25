using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Data.Repositories;
using Domain;
using Domain.Repositories;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace Presentation
{
    public partial class MainForm : Form
    {
        private IMapMarkerRepository _mapMarkerRepository;
        public MainForm(string bdConnectionConfiguration)
        {
            InitializeComponent();
            try
            {
                _mapMarkerRepository = MapMarkerRepository.GetInstance(bdConnectionConfiguration);
                _mapMarkerRepository.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к бд: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void gMapControl_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly; 
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl.MinZoom = 2; 
            gMapControl.MaxZoom = 16;
            gMapControl.Zoom = 10; 
            gMapControl.Position = new GMap.NET.PointLatLng(55, 82.9);
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; 
            gMapControl.CanDragMap = true; 
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.ShowCenter = false; 
            gMapControl.ShowTileGridLines = false;
            
            gMapControl.Overlays.Add(
                CreateGoogleMarkers(_mapMarkerRepository.Read())
                );
        }

        private GMapOverlay CreateGoogleMarkers(IEnumerable<MapMarker> markers)
        {
            var gmarkers = new GMapOverlay("markers");
            foreach (var marker in markers)
            {
                var gmarker = new GMarkerGoogle(
                    new GMap.NET.PointLatLng(marker.Latitude, marker.Longitude), 
                    GMarkerGoogleType.red)
                {
                    ToolTipText = marker.Name,
                    Tag = marker.Id.ToString()
                };
                gmarkers.Markers.Add(gmarker);
            }
            return gmarkers;
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            currentMarker = item;
        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            currentMarker = null;
        }


        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMarker is null) return;
            isMouseDown = true;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown || currentMarker is null) return;
            
            currentMarker.Position = gMapControl.FromLocalToLatLng(e.Location.X, e.Location.Y);
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown && currentMarker is not null)
            {
                _mapMarkerRepository.Update(new MapMarker(
                    Convert.ToInt32(currentMarker.Tag),
                    currentMarker.ToolTipText,
                    currentMarker.Position.Lat, 
                    currentMarker.Position.Lng)
                );
            }
            isMouseDown = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mapMarkerRepository.Close();
        }

    }
}
