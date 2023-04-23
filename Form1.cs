using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib;
using PeopleAppGlobals;
using EditPerson;
using PeopleLib;


/*
*Controls
* TeacherButton
* StudentButton
* ImageList 
* SplitContainer
* FlowLayoutPanel
* Panel
* ToolStrip
* ToolStripLinkLabel
*ToolStripButton * EmailLabel
*PhotoGroupBox
* PhotoPictureBox
* PlusImage
* Minus Image
* PeopleGlobals.dll
* EditPerson.dll
*/

namespace DynamicPeople
/// Author: Yanzhi Wang
/// Purpose: The Form1 class is the main form for the application. It provides a UI for displaying and managing lists of people, including teachers and students.
/// Restrictions: None.
/// Known errors: None.
{
    public partial class Form1 : Form
    {
        // Set up event handlers for buttons and initialize the form.
        public Form1()
        {
            InitializeComponent(); // Initialize the form components from the designer file.

            Globals.AddPeopleSampleData(); // Add sample data to the global list of people.

            // Set up event handlers for the teacher and student buttons.
            this.teacherButton.Click += new EventHandler(TeacherButton_Click);
            this.studentButton.Click += new EventHandler(StudentButton_Click);

            this.panel1.Visible = false; // Hide the panel by default.
        }

        // Event handler for the teacher button click event.
        private void TeacherButton_Click(object sender, EventArgs e)
        {
            // Clear any existing controls from the flow layout panel.
            this.flowLayoutPanel1.Controls.Clear();

            // Loop through the list of people and add any teachers to the flow layout panel.
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if (keyValuePair.Value.GetType() == typeof(Teacher))
                {
                    AddPanel(keyValuePair.Value); // Add a panel containing information about the teacher to the flow layout panel.
                }
                teacherButton.Text = this.flowLayoutPanel1.Controls.Count.ToString(); // Update the teacher button text to show the number of teachers displayed.
            }
        }


        // Event handler for the student button click event.
        private void StudentButton_Click(object sender, EventArgs e)
        {
            // Clear any existing controls from the flow layout panel.
            this.flowLayoutPanel1.Controls.Clear();

            // Loop through the list of people and add any students to the flow layout panel.
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if (keyValuePair.Value.GetType() == typeof(Student))
                {
                    AddPanel(keyValuePair.Value); // Add a panel containing information about the student to the flow layout panel.
                }
                studentButton.Text = this.flowLayoutPanel1.Controls.Count.ToString(); // Update the student button text to show the number of students displayed.
            }
        }

        // Adds a panel containing information about a person to the flow layout panel.
        private void AddPanel(Person person)
        {
            Panel panel1 = new System.Windows.Forms.Panel(); // Create a new panel to hold the person's information.

            AddPersonToPanel(ref panel1, person); // Add the person's information to the panel.

            // Add the panel to the flow layout panel and set its position to the end of the list.
            this.flowLayoutPanel1.Controls.Add(panel1);
            this.flowLayoutPanel1.Controls.SetChildIndex(panel1, flowLayoutPanel1.Controls.Count);
        }

        // Adds the given person's information to the given panel.
        private void AddPersonToPanel(ref Panel panel1, Person person)
        {
            // Create new form components to hold the person's information.
            ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
            ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ToolStripLabel toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            Label emailLabel = new System.Windows.Forms.Label();
            GroupBox photoGroupBox = new System.Windows.Forms.GroupBox();
            PictureBox photoPictureBox = new System.Windows.Forms.PictureBox();




            // panel1
          panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D; 
          panel1.Controls.Add(emailLabel); 
          panel1.Controls.Add(photoGroupBox);
          panel1.Controls.Add(toolStrip1);
          panel1.Location = new System.Drawing.Point(1, 3);
          panel1.Name = "panel1";
          panel1.Size = new System.Drawing.Size(189, 159);
          panel1.TabIndex = 0;
            panel1.Tag = person;
            //


            // toolStripButton1
            //
           toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           toolStripButton1.Image = global::DynamicPeople.Properties.Resources.plus;
           toolStripButton1.Name = "toolStripButton1";
           toolStripButton1.Size = new System.Drawing.Size(23, 22);
           toolStripButton1.Text = "toolStripButton1";
           toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
           toolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
           toolStripButton1.Tag = panel1;

            // toolStripLabel1
            toolStripLabel1.AutoSize = false;
           toolStripLabel1.IsLink = true;
           toolStripLabel1.Name = "toolStripLabel1";
           toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No; this.toolStripLabel1.Size = new System.Drawing.Size(140, 22);
           toolStripLabel1.Text = person.name;
           toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolStripLabel1.Click += new EventHandler(ToolStripLabel1_Click);
            toolStripLabel1.Tag = panel1;


            // toolStrip1
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
           toolStripButton1,
           toolStripLabel1});
           toolStrip1.Location = new System.Drawing.Point(0, 0);
           toolStrip1.Name = "toolStrip1";
           toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes; this.toolStrip1.Size = new System.Drawing.Size(185, 25);
           toolStrip1.TabIndex = 0;
           toolStrip1.Text = "toolStrip1";

            // emailLabel
            emailLabel.Location =  new System.Drawing.Point(12, 31); 
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(170, 23);
            emailLabel.TabIndex = 1;
            this.emailLabel.Text = person.email;


            //
            // photoGroupBox
           photoGroupBox.Controls.Add(photoPictureBox); 
           photoGroupBox.Location = new System.Drawing.Point(15, 57); 
           photoGroupBox.Name = "photoGroupBox";
           photoGroupBox.Size = new System.Drawing.Size(114, 95);
           photoGroupBox.TabIndex = 52;
           photoGroupBox.TabStop = false;
           photoGroupBox.Text = "Photo";

            //
            // photoPictureBox
            //
           photoPictureBox.BackColor = System.Drawing.Color.LightGray;
           photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
           photoPictureBox.Location = new System.Drawing.Point(3, 16); 
           photoPictureBox.Name = "photoPictureBox";
            photoPictureBox.Size = new System.Drawing.Size(108, 76);
            photoPictureBox.ImageLocation = person.photoPath;
            photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
           photoPictureBox.TabIndex = 0;
           photoPictureBox.TabStop = false;
        }


        // Event handler for when the ToolStripButton is clicked.
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            // Cast the sender object to a ToolStripButton and retrieve the associated panel.
            ToolStripButton tsb = (ToolStripButton)sender;
            Panel p = (Panel)tsb.Tag;

            // Check if the button is checked (i.e., if the panel is expanded).
            if (tsb.Checked)
            {
                // If the button is checked, collapse the panel and change the button image.
                tsb.Image = global::DynamicPeople.Properties.Resources.plus;
                p.Size = new System.Drawing.Size(189, 25);
                tsb.Checked = false;
            }
            else
            {
                // If the button is not checked, expand the panel and change the button image.
                tsb.Image = global::DynamicPeople.Properties.Resources.minus;
                p.Size = new System.Drawing.Size(189, 159); tsb.Checked = true;
            }

            // Refresh the panel to reflect the changes.
            p.Refresh();
        }


        // Event handler for when the ToolStripLabel is clicked.
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            // Cast the sender object to a ToolStripLabel and retrieve the associated panel.
            ToolStripLabel ts1 = (ToolStripLabel)sender;
            Panel p = (Panel)ts1.Tag;

            // Create a new PersonEditForm and display it as a dialog.
            PersonEditForm pef = new PersonEditForm((Person)p.Tag, this);
            pef.Visible = false;
            pef.ShowDialog();

            // Retrieve the Person object from the form and clear the panel.
            Person person = pef.formPerson;
            p.Controls.Clear();

            // Add the updated Person to the panel and refresh it to reflect the changes.
            AddPersonToPanel(ref p, person);
            p.Refresh();
        }

    }
}