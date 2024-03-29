// Copyright 2006 Bret Taylor
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Drawing;
using System.Windows.Forms;
using Stickies.Resources;

namespace Stickies.Notes {
  /// <summary>
  /// A simple control that displays all of our note display preferences.
  /// We reuse this control in our global Stickies preferences and our
  /// NoteSettingsDialog form.
  /// </summary>
  public partial class NotePreferencesControl : UserControl {
    public delegate void NotePreferencesHandler();

    /// <summary>
    /// Fired when the note background color preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteBackgroundColorChanged;

    /// <summary>
    /// Fired when the note border color preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteBorderColorChanged;

    /// <summary>
    /// Fired when the note font color preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteFontColorChanged;

    /// <summary>
    /// Fired when the note font preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteFontChanged;

    /// <summary>
    /// Fired when the note transparency preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteTransparencyChanged;

    /// <summary>
    /// Fired when the note "always on top" preference is set.
    /// </summary>
    public event NotePreferencesHandler NoteAlwaysOnTopChanged;

    /// <summary>
    /// Creates a new note preferences control.
    /// </summary>
    public NotePreferencesControl() {
      InitializeComponent();
      borderColorLabel_.Text = LocaleHelper.GetString("Messages.PreferencesNoteBorderColor");
      borderColorButton_.Text = LocaleHelper.GetString("Messages.PreferencesNoteChange");
      backgroundColorLabel_.Text = LocaleHelper.GetString("Messages.PreferencesNoteBackgroundColor");
      backgroundColorButton_.Text = LocaleHelper.GetString("Messages.PreferencesNoteChange");
      fontLabel_.Text = LocaleHelper.GetString("Messages.PreferencesNoteFont");
      fontButton_.Text = LocaleHelper.GetString("Messages.PreferencesNoteChange");
      alwaysOnTopCheckBox_.Text = LocaleHelper.GetString("Messages.PreferencesNoteAlwaysOnTop");
      opaqueLabel_.Text = LocaleHelper.GetString("Messages.PreferencesNoteOpaque");
      invisibleLabel_.Text = LocaleHelper.GetString("Messages.PreferencesNoteInvisible");
      UpdateTransparencyLabel();

      // Since slider bar controls do not support transparent backgrounds, this
      // is a hack to make our control display correctly in most forms by
      // copying over the correct background color from parent controls.
      for (Control parent = this.Parent; parent != null; parent = parent.Parent) {
        if (parent.BackColor != Color.Transparent) {
          transparencyBar_.BackColor = parent.BackColor;
          break;
        }
      }
    }

    /// <summary>
    /// Updates the transparency label, which shows the numerical transparency
    /// of the transparency slider bar.
    /// </summary>
    private void UpdateTransparencyLabel() {
      transparencyLabel_.Text = String.Format(LocaleHelper.GetString("Messages.PreferencesNoteTransparency"), transparencyBar_.Value);
    }

    /// <summary>
    /// Gets or sets the note background color preference.
    /// </summary>
    public Color NoteBackgroundColor {
      get {
        return backgroundColorPreviewPanel_.BackColor;
      }
      set {
        backgroundColorPreviewPanel_.BackColor = value;
        fontPreviewLabel_.BackColor = value;
        if (NoteBackgroundColorChanged != null) {
          NoteBackgroundColorChanged();
        }
      }
    }

    /// <summary>
    /// Gets or sets the note border color preference.
    /// </summary>
    public Color NoteBorderColor {
      get {
        return borderColorPreviewPanel_.BackColor;
      }
      set {
        borderColorPreviewPanel_.BackColor = value;
        if (NoteBorderColorChanged != null) {
          NoteBorderColorChanged();
        }
      }
    }

    /// <summary>
    /// Gets or sets the note font preference.
    /// </summary>
    public Font NoteFont {
      get {
        return fontPreviewLabel_.Font;
      }
      set {
        fontPreviewLabel_.Font = value;
        if (NoteFontChanged != null) {
          NoteFontChanged();
        }
      }
    }

    /// <summary>
    /// Gets or sets the note font color preference.
    /// </summary>
    public Color NoteFontColor {
      get {
        return fontPreviewLabel_.ForeColor;
      }
      set {
        fontPreviewLabel_.ForeColor = value;
        if (NoteFontColorChanged != null) {
          NoteFontColorChanged();
        }
      }
    }

    /// <summary>
    /// Gets or sets the note transparency preference.
    /// </summary>
    public double NoteTransparency {
      get {
        return transparencyBar_.Value / (double) transparencyBar_.Maximum;
      }
      set {
        transparencyBar_.Value = Math.Min(transparencyBar_.Maximum, Math.Max(0, (int) (value * transparencyBar_.Maximum)));
      }
    }

    /// <summary>
    /// Gets or sets the note "Always on top" preference.
    /// </summary>
    public bool NoteAlwaysOnTop {
      get {
        return alwaysOnTopCheckBox_.Checked;
      }
      set {
        alwaysOnTopCheckBox_.Checked = value;
      }
    }

    private void borderColorButton__Click(object sender, EventArgs e) {
      colorDialog_.Color = borderColorPreviewPanel_.BackColor;
      if (colorDialog_.ShowDialog(this.ParentForm) == DialogResult.OK) {
        this.NoteBorderColor = colorDialog_.Color;
      }
    }

    private void backgroundColorButton__Click(object sender, EventArgs e) {
      colorDialog_.Color = backgroundColorPreviewPanel_.BackColor;
      if (colorDialog_.ShowDialog(this.ParentForm) == DialogResult.OK) {
        this.NoteBackgroundColor = colorDialog_.Color;
      }
    }

    private void fontButton__Click(object sender, EventArgs e) {
      fontDialog_.Font = fontPreviewLabel_.Font;
      fontDialog_.Color = fontPreviewLabel_.ForeColor;
      if (fontDialog_.ShowDialog(this.ParentForm) == DialogResult.OK) {
        this.NoteFontColor = fontDialog_.Color;
        this.NoteFont = fontDialog_.Font;
      }
    }

    private void alwaysOnTopCheckBox__CheckedChanged(object sender, EventArgs e) {
      if (NoteAlwaysOnTopChanged != null) {
        NoteAlwaysOnTopChanged();
      }
    }

    private void transparencyBar__ValueChanged(object sender, EventArgs e) {
      if (NoteTransparencyChanged != null) {
        NoteTransparencyChanged();
      }
      UpdateTransparencyLabel();
    }

    /// <summary>
    /// Since slider bar controls do not support transparent backgrounds, it
    /// is sometimes necessary to set the background color of the transparency
    /// slider bar manually to get this control to display correctly. This
    /// property makes it easy for clients to do that.
    /// </summary>
    public Color SliderBarBackColor {
      get {
        return transparencyBar_.BackColor;
      }
      set {
        transparencyBar_.BackColor = value;
      }
    }
  }
}
