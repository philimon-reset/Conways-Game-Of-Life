﻿//-----------------------------------------------------------------------
// <copyright file="SoftRendererForm.cs" company="SoftRenderer">
// Copyright (c) SoftRenderer. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------



namespace SoftRenderer.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
<<<<<<< HEAD:SoftRendererForm.cs
    using SoftRenderer.Client.WindowFactory;
=======
>>>>>>> 9b5cfb50e969b87caa28591513c6bb9b7d6c7c8e:Client/SoftRendererForm.cs
    using SoftRenderer.Engine;
    using SoftRenderer.Engine.Render.Technique.Canvas;
    using SoftRenderer.Engine.Render.Technique.Rasterizer;
    using SoftRenderer.Engine.Render.Technique.RayTracer;
    using SoftRenderer.Utility.Win32;

    /// <summary>
    /// soft renderer form window.
    /// </summary>
    public class SoftRendererForm : Form, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoftRendererForm"/> class.
        /// </summary>
        public SoftRendererForm()
        {
            this.General = WindowFactory.RenderBaseSeed(2) as General;
            // this.RayTraceBase = WindowFactory.RenderBaseSeed<RayTracer>(1);
            this.RenderBases = new IRenderBase[] { this.General };
            while (Application.OpenForms.Count >= 1)
            {
                this.Render();
                // Thread.Sleep(1000);
                Application.DoEvents();
            }
        }

        private IEnumerable<IRenderBase> RenderBases { get; }

        /// <summary>
        /// Gets or sets raster port.
        /// </summary>
        private Rasterizer RasterBase { get; set; }

        /// <summary>
        /// Gets or sets raytracer port.
        /// </summary>
        private RayTracer RayTraceBase { get; set; }

        /// <summary>
        /// Gets or sets Canvas port.
        /// </summary>
        private Canvas CanvasBase { get; set; }

        /// <summary>
        /// Gets or sets Canvas port.
        /// </summary>
        private General General { get; set; }

        /// <summary>
        /// Render all the available bases.
        /// </summary>
        public void Render()
        {
            foreach (var renderBase in this.RenderBases)
            {
                if (DLL.IsWindow(renderBase.HostHandle))
                {
                    renderBase.Render();
                }
            }
        }

        /// <summary>
        /// Dispose RenderBases and set RenderBases list as default.
        /// </summary>
        public new void Dispose()
        {
            this.RasterBase.Dispose();
            this.RayTraceBase.Dispose();
            this.CanvasBase.Dispose();
            this.RayTraceBase = default;
            this.RasterBase = default;
            this.CanvasBase = default;
        }
    }
}