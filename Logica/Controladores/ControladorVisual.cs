using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorVisual
    {
        private static string mensajeAdmStma {
            get
            { return "Si el problema persiste, póngase en contacto con el administrador del sistema."; }
        }

        public static DialogResult mostrarMensaje(ResultadoOperacion resultadoOperacion)
        {
            switch (resultadoOperacion.estadoOperacion)
            {
                // Estados dependientes del usuario
                case EstadoOperacion.Correcto:
                    return MessageBox.Show(
                        resultadoOperacion.ToString(),
                        "Éxito", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );

                case EstadoOperacion.NingunResultado:
                case EstadoOperacion.ErrorCredencialesIncorrectas:
                case EstadoOperacion.ErrorDatosIncorrectos:
                case EstadoOperacion.ErrorDependenciaDeDatos:
                    return MessageBox.Show(
                        resultadoOperacion.ToString(),
                        "Aviso", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning
                    );
                


                    // Estados no dependientes del usuario
                default:
                    return MessageBox.Show(
                        resultadoOperacion.ToString() + "\n" + mensajeAdmStma,
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );
            }
        }

        public static ComboBox clonarCombo(ComboBox comboOriginal)
        {
            ComboBox comboNuevo = new ComboBox();

            //comboNuevo.AccessibilityObject = comboOriginal.AccessibilityObject;
            //comboNuevo.AccessibleDefaultActionDescription = comboOriginal.AccessibleDefaultActionDescription;
            /*comboNuevo.AccessibleDescription = comboOriginal.AccessibleDescription;
            comboNuevo.AccessibleName = comboOriginal.AccessibleName;
            comboNuevo.AccessibleRole = comboOriginal.AccessibleRole;
            comboNuevo.AllowDrop = comboOriginal.AllowDrop;
            comboNuevo.Anchor = comboOriginal.Anchor;
            comboNuevo.AutoCompleteCustomSource = comboOriginal.AutoCompleteCustomSource;
            comboNuevo.AutoCompleteMode = comboOriginal.AutoCompleteMode;
            comboNuevo.AutoCompleteSource = comboOriginal.AutoCompleteSource;
            comboNuevo.AutoScrollOffset = comboOriginal.AutoScrollOffset;*/
            comboNuevo.BackColor = comboOriginal.BackColor;
            /*comboNuevo.BindingContext = comboOriginal.BindingContext;
            //comboNuevo.Bottom = comboOriginal.Bottom;
            comboNuevo.Bounds = comboOriginal.Bounds;
            //comboNuevo.CanFocus = comboOriginal.CanFocus;
            //comboNuevo.CanSelect = comboOriginal.CanSelect;
            comboNuevo.Capture = comboOriginal.Capture;
            comboNuevo.CausesValidation = comboOriginal.CausesValidation;
            //comboNuevo.ClientRectangle = comboOriginal.ClientRectangle;
            comboNuevo.ClientSize = comboOriginal.ClientSize;
            //comboNuevo.CompanyName = comboOriginal.CompanyName;
            //comboNuevo.Container = comboOriginal.Container;
            //comboNuevo.ContainsFocus = comboOriginal.ContainsFocus;
            comboNuevo.ContextMenu = comboOriginal.ContextMenu;
            comboNuevo.ContextMenuStrip = comboOriginal.ContextMenuStrip;
            //comboNuevo.Controls = comboOriginal.Controls;
            //comboNuevo.Created = comboOriginal.Created;
            comboNuevo.Cursor = comboOriginal.Cursor;*/
            //comboNuevo.DataBindings = comboOriginal.DataBindings;
            /*comboNuevo.DataSource = comboOriginal.DataSource;*/
            /*comboNuevo.DisplayMember = comboOriginal.DisplayMember;
            //comboNuevo.DisplayRectangle = comboOriginal.DisplayRectangle;
            //comboNuevo.Disposing = comboOriginal.Disposing;
            comboNuevo.Dock = comboOriginal.Dock;
            comboNuevo.DrawMode = comboOriginal.DrawMode;
            comboNuevo.DropDownHeight = comboOriginal.DropDownHeight;*/
            comboNuevo.DropDownStyle = comboOriginal.DropDownStyle;
            /*comboNuevo.DropDownWidth = comboOriginal.DropDownWidth;
            comboNuevo.DroppedDown = comboOriginal.DroppedDown;
            comboNuevo.Enabled = comboOriginal.Enabled;
            comboNuevo.FlatStyle = comboOriginal.FlatStyle;*/
            //comboNuevo.Focused = comboOriginal.Focused;
            comboNuevo.Font = comboOriginal.Font;
            comboNuevo.ForeColor = comboOriginal.ForeColor;
            /*comboNuevo.FormatInfo = comboOriginal.FormatInfo;
            comboNuevo.FormatString = comboOriginal.FormatString;
            //comboNuevo.FormattingEnabled = comboOriginal.FormattingEnabled;
            //comboNuevo.Handle = comboOriginal.Handle;
            //comboNuevo.HasChildren = comboOriginal.HasChildren;
            comboNuevo.Height = comboOriginal.Height;
            comboNuevo.ImeMode = comboOriginal.ImeMode;
            comboNuevo.IntegralHeight = comboOriginal.IntegralHeight;
            //comboNuevo.InvokeRequired = comboOriginal.InvokeRequired;
            comboNuevo.IsAccessible = comboOriginal.IsAccessible;
            //comboNuevo.IsDisposed = comboOriginal.IsDisposed;
            //comboNuevo.IsHandleCreated = comboOriginal.IsHandleCreated;
            //comboNuevo.IsMirrored = comboOriginal.IsMirrored;
            comboNuevo.ItemHeight = comboOriginal.ItemHeight;
            //comboNuevo.Items = comboOriginal.Items;
            //comboNuevo.LayoutEngine = comboOriginal.LayoutEngine;
            comboNuevo.Left = comboOriginal.Left;
            comboNuevo.Location = comboOriginal.Location;
            comboNuevo.Margin = comboOriginal.Margin;
            comboNuevo.MaxDropDownItems = comboOriginal.MaxDropDownItems;
            comboNuevo.MaximumSize = comboOriginal.MaximumSize;
            comboNuevo.MaxLength = comboOriginal.MaxLength;
            comboNuevo.MinimumSize = comboOriginal.MinimumSize;
            comboNuevo.Name = comboOriginal.Name;
            comboNuevo.Parent = comboOriginal.Parent;*/
            //comboNuevo.PreferredHeight = comboOriginal.PreferredHeight;
            //comboNuevo.PreferredSize = comboOriginal.PreferredSize;
            //comboNuevo.ProductName = comboOriginal.ProductName;
            //comboNuevo.ProductVersion = comboOriginal.ProductVersion;
            //comboNuevo.RecreatingHandle = comboOriginal.RecreatingHandle;
            /*comboNuevo.Region = comboOriginal.Region;
            //comboNuevo.Right = comboOriginal.Right;
            comboNuevo.RightToLeft = comboOriginal.RightToLeft;
            comboNuevo.SelectedIndex = comboOriginal.SelectedIndex;
            comboNuevo.SelectedItem = comboOriginal.SelectedItem;
            comboNuevo.SelectedText = comboOriginal.SelectedText;
            //comboNuevo.SelectedValue = comboOriginal.SelectedValue;
            comboNuevo.SelectionLength = comboOriginal.SelectionLength;
            comboNuevo.SelectionStart = comboOriginal.SelectionStart;
            comboNuevo.Site = comboOriginal.Site;*/
            comboNuevo.Size = comboOriginal.Size;
            /*comboNuevo.Sorted = comboOriginal.Sorted;
            comboNuevo.TabIndex = comboOriginal.TabIndex;
            comboNuevo.TabStop = comboOriginal.TabStop;
            comboNuevo.Tag = comboOriginal.Tag;
            comboNuevo.Text = comboOriginal.Text;
            comboNuevo.Top = comboOriginal.Top;
            //comboNuevo.TopLevelControl = comboOriginal.TopLevelControl;
            comboNuevo.UseWaitCursor = comboOriginal.UseWaitCursor;
            comboNuevo.ValueMember = comboOriginal.ValueMember;
            comboNuevo.Visible = comboOriginal.Visible;
            comboNuevo.Width = comboOriginal.Width;*/

            return comboNuevo;
        }

        public static TextBox clonarTextBox(TextBox txtOriginal)
        {
            TextBox txtNuevo = new TextBox();

            /*txtNuevo.AcceptsReturn = txtOriginal.AcceptsReturn;
            txtNuevo.AcceptsTab = txtOriginal.AcceptsTab;
            //txtNuevo.AccessibilityObject = txtOriginal.AccessibilityObject;
            txtNuevo.AccessibleDefaultActionDescription = txtOriginal.AccessibleDefaultActionDescription;
            txtNuevo.AccessibleDescription = txtOriginal.AccessibleDescription;
            txtNuevo.AccessibleName = txtOriginal.AccessibleName;
            txtNuevo.AccessibleRole = txtOriginal.AccessibleRole;
            txtNuevo.AllowDrop = txtOriginal.AllowDrop;
            txtNuevo.Anchor = txtOriginal.Anchor;
            txtNuevo.AutoCompleteCustomSource = txtOriginal.AutoCompleteCustomSource;
            txtNuevo.AutoCompleteMode = txtOriginal.AutoCompleteMode;
            txtNuevo.AutoCompleteSource = txtOriginal.AutoCompleteSource;
            txtNuevo.AutoScrollOffset = txtOriginal.AutoScrollOffset;*/
            txtNuevo.BackColor = txtOriginal.BackColor;
            /*txtNuevo.BindingContext = txtOriginal.BindingContext;
            txtNuevo.BorderStyle = txtOriginal.BorderStyle;*/
            //txtNuevo.Bottom = txtOriginal.Bottom;
            /*txtNuevo.Bounds = txtOriginal.Bounds;
            //txtNuevo.CanFocus = txtOriginal.CanFocus;
            //txtNuevo.CanSelect = txtOriginal.CanSelect;
            //txtNuevo.CanUndo = txtOriginal.CanUndo;
            txtNuevo.Capture = txtOriginal.Capture;
            txtNuevo.CausesValidation = txtOriginal.CausesValidation;
            txtNuevo.CharacterCasing = txtOriginal.CharacterCasing;
            //txtNuevo.ClientRectangle = txtOriginal.ClientRectangle;
            txtNuevo.ClientSize = txtOriginal.ClientSize;
            //txtNuevo.CompanyName = txtOriginal.CompanyName;
            //txtNuevo.Container = txtOriginal.Container;
            //txtNuevo.ContainsFocus = txtOriginal.ContainsFocus;
            txtNuevo.ContextMenu = txtOriginal.ContextMenu;
            txtNuevo.ContextMenuStrip = txtOriginal.ContextMenuStrip;
            //txtNuevo.Controls = txtOriginal.Controls;
            //txtNuevo.Created = txtOriginal.Created;
            txtNuevo.Cursor = txtOriginal.Cursor;
            //txtNuevo.DataBindings = txtOriginal.DataBindings;
            //txtNuevo.DisplayRectangle = txtOriginal.DisplayRectangle;
            //txtNuevo.Disposing = txtOriginal.Disposing;
            txtNuevo.Dock = txtOriginal.Dock;*/
            /*txtNuevo.Enabled = txtOriginal.Enabled;*/
            //txtNuevo.Focused = txtOriginal.Focused;
            txtNuevo.Font = txtOriginal.Font;
            txtNuevo.ForeColor = txtOriginal.ForeColor;
            //txtNuevo.Handle = txtOriginal.Handle;
            //txtNuevo.HasChildren = txtOriginal.HasChildren;
            txtNuevo.Height = txtOriginal.Height;
            /*txtNuevo.HideSelection = txtOriginal.HideSelection;
            txtNuevo.ImeMode = txtOriginal.ImeMode;
            //txtNuevo.InvokeRequired = txtOriginal.InvokeRequired;
            txtNuevo.IsAccessible = txtOriginal.IsAccessible;
            //txtNuevo.IsDisposed = txtOriginal.IsDisposed;
            //txtNuevo.IsHandleCreated = txtOriginal.IsHandleCreated;
            //txtNuevo.IsMirrored = txtOriginal.IsMirrored;
            //txtNuevo.LayoutEngine = txtOriginal.LayoutEngine;
            txtNuevo.Left = txtOriginal.Left;
            txtNuevo.Lines = txtOriginal.Lines;
            txtNuevo.Location = txtOriginal.Location;
            txtNuevo.Margin = txtOriginal.Margin;
            txtNuevo.MaximumSize = txtOriginal.MaximumSize;
            txtNuevo.MaxLength = txtOriginal.MaxLength;
            txtNuevo.MinimumSize = txtOriginal.MinimumSize;
            txtNuevo.Modified = txtOriginal.Modified;*/
            txtNuevo.Multiline = txtOriginal.Multiline;
            /*txtNuevo.Name = txtOriginal.Name;
            txtNuevo.Parent = txtOriginal.Parent;
            txtNuevo.PasswordChar = txtOriginal.PasswordChar;*/
            //txtNuevo.PreferredHeight = txtOriginal.PreferredHeight;
            //txtNuevo.PreferredSize = txtOriginal.PreferredSize;
            //txtNuevo.ProductName = txtOriginal.ProductName;
            //txtNuevo.ProductVersion = txtOriginal.ProductVersion;
            txtNuevo.ReadOnly = txtOriginal.ReadOnly;
            //txtNuevo.RecreatingHandle = txtOriginal.RecreatingHandle;
            /*txtNuevo.Region = txtOriginal.Region;*/
            //txtNuevo.Right = txtOriginal.Right;
            /*txtNuevo.RightToLeft = txtOriginal.RightToLeft;*/
            txtNuevo.ScrollBars = txtOriginal.ScrollBars;
            /*txtNuevo.SelectedText = txtOriginal.SelectedText;
            txtNuevo.SelectionLength = txtOriginal.SelectionLength;
            txtNuevo.SelectionStart = txtOriginal.SelectionStart;
            txtNuevo.ShortcutsEnabled = txtOriginal.ShortcutsEnabled;
            txtNuevo.Site = txtOriginal.Site;*/
            /*txtNuevo.Size = txtOriginal.Size;*/
            /*txtNuevo.TabIndex = txtOriginal.TabIndex;
            txtNuevo.TabStop = txtOriginal.TabStop;
            txtNuevo.Tag = txtOriginal.Tag;*/
            txtNuevo.Text = txtOriginal.Text;
            txtNuevo.TextAlign = txtOriginal.TextAlign;
            //txtNuevo.TextLength = txtOriginal.TextLength;
            /*txtNuevo.Top = txtOriginal.Top;
            //txtNuevo.TopLevelControl = txtOriginal.TopLevelControl;
            txtNuevo.UseSystemPasswordChar = txtOriginal.UseSystemPasswordChar;
            txtNuevo.UseWaitCursor = txtOriginal.UseWaitCursor;*/
            /*txtNuevo.Visible = txtOriginal.Visible;*/
            txtNuevo.Width = txtOriginal.Width;
            /*txtNuevo.WordWrap = txtOriginal.WordWrap;*/

            return txtNuevo;
        }

        // Métodos misceláneos
        // Evento
        public static void evitarScroll(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
