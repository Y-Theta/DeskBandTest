using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsDeskBand.DeskBand.Interop.Struct;

namespace WindowsDeskBand.DeskBand.BandParts {
    /// <summary>
    /// The orientation of the taskbar.
    /// </summary>
    public enum TaskbarOrientation {
        /// <summary>
        /// Vertical if the taskbar is either on top or bottom.
        /// </summary>
        Vertical,
        /// <summary>
        /// Horizontal if the taskbar is either on the left or right.
        /// </summary>
        Horizontal,
    }

    /// <summary>
    /// The edge where the taskbar is located.
    /// </summary>
    public enum Edge : uint {
        /// <summary>
        /// Taskbar is on the left edge.
        /// </summary>
        Left,
        /// <summary>
        /// Taskbar is on the top edge.
        /// </summary>
        Top,
        /// <summary>
        /// Taskbar is on the right edge.
        /// </summary>
        Right,
        /// <summary>
        /// Taskbar is on the bottom edge.
        /// </summary>
        Bottom,
    }

    /// <summary>
    /// Provides information about the main taskbar.
    /// </summary>
    public sealed class TaskbarInfo {
        /// <summary>
        /// Get the current <see cref="TaskbarOrientation"/> of the main taskbar.
        /// </summary>
        /// <value>
        /// The current orientation.
        /// </value>
        public TaskbarOrientation Orientation {
            get => _orientation;
            private set {
                if (value == _orientation) {
                    return;
                }

                _orientation = value;
                TaskbarOrientationChanged?.Invoke(this, new TaskbarOrientationChangedEventArgs { Orientation = value });
            }
        }

        /// <summary>
        /// Get the current <see cref="CSDeskBand.Edge"/> of the main taskbar.
        /// </summary>
        /// <value>
        /// The current edge.
        /// </value>
        public Edge Edge {
            get => _edge;
            private set {
                if (value == _edge) {
                    return;
                }

                _edge = value;
                TaskbarEdgeChanged?.Invoke(this, new TaskbarEdgeChangedEventArgs { Edge = value });
            }
        }

        /// <summary>
        /// Get the current <see cref="CSDeskBand.Size"/> of the main taskbar.
        /// </summary>
        /// <value>
        /// The current size.
        /// </value>
        public BandSize Size {
            get => _size;
            private set {
                if (value.Equals(_size)) {
                    return;
                }

                _size = value;
                TaskbarSizeChanged?.Invoke(this, new TaskbarSizeChangedEventArgs { Size = value });
            }
        }

        /// <summary>
        /// Occurs when the orientation of the main taskbar is changed.
        /// </summary>
        public event EventHandler<TaskbarOrientationChangedEventArgs> TaskbarOrientationChanged;

        /// <summary>
        /// Occurs when the edge of the main taskbar is changed.
        /// </summary>
        public event EventHandler<TaskbarEdgeChangedEventArgs> TaskbarEdgeChanged;

        /// <summary>
        /// Occurs when the size of the taskbar is changed.
        /// </summary>
        public event EventHandler<TaskbarSizeChangedEventArgs> TaskbarSizeChanged;

        private TaskbarOrientation _orientation = TaskbarOrientation.Horizontal;
        private Edge _edge = Edge.Bottom;
        private BandSize _size;

        internal TaskbarInfo() {
            UpdateInfo();
        }

        internal void UpdateInfo() {

            APPBARDATA data = new APPBARDATA {
                hWnd = IntPtr.Zero,
                cbSize = Marshal.SizeOf<APPBARDATA>()
            };
            var res = Shell32.SHAppBarMessage(APPBARMESSAGE.ABM_GETTASKBARPOS, ref data);
            if (!Convert.ToBoolean((int)res)) {
            }

            var rect = data.rc;
            Size = new BandSize(rect.right - rect.left, rect.bottom - rect.top);
            Edge = (Edge)data.uEdge;
            Orientation = (Edge == Edge.Bottom || Edge == Edge.Top) ? TaskbarOrientation.Horizontal : TaskbarOrientation.Vertical;
        }
    }
}
