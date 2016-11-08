/*
 * Name : Anju Chawla
 * Date : November, 2016
 * Purpose: To allow the user to select coffee and syrup flavours.
 * New coffee flavours can be added and old ones removed. 
 * The entire coffee list can be cleared and number of coffee\flavours can be displayed.
 * Can print all available coffee flavours and only selected ones too.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collections
{
    public partial class CoffeeSyrupForm : Form
    {
        public CoffeeSyrupForm()
        {
            InitializeComponent();
        }

        private void printSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //print selected flavours

            if (syrupListBox.SelectedIndex == -1)
            {
                syrupListBox.SelectedIndex = 0;
            }

            if (coffeeComboBox.SelectedIndex != -1)
            {
                printSelectedDocument.Print();
            }
            else
            {
                MessageBox.Show("Please select a coffee flavour", "Print Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }
        }

        private void previewSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (syrupListBox.SelectedIndex == -1)
            {
                syrupListBox.SelectedIndex = 0;
            }

            if (coffeeComboBox.SelectedIndex != -1)
            {
                printPreviewDialog1.Document = printSelectedDocument;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a coffee flavour", "Print Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }
        }

        private void printAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print all flavours
            printAllDocument.Print();

        }

        private void previewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //preview the coffee flavours
            printPreviewDialog1.Document = printAllDocument;
            printPreviewDialog1.ShowDialog();

        }

        private void printAllDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            // Handle printing and print previews when printing all.

            Font printFont = new Font("Arial", 12);
            float lineHeightFloat = printFont.Height + 2;
            float horizontalPrintLocationFloat = e.MarginBounds.Left;
            float verticalPrintLocationFloat = e.MarginBounds.Top;
            string printLineString;

            //Print the heading for coffee flavours
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            e.Graphics.DrawString("Coffee Flavours", headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);
           
            // Show all coffee flavours
            //for (int ListIndexInteger = 0; ListIndexInteger < CoffeeComboBox.Items.Count - 1; ListIndexInteger++)
            foreach (Object flavor in coffeeComboBox.Items)
            {
                //increment the  Y position for the next line.
                verticalPrintLocationFloat += lineHeightFloat;

                //Set up a line
                //printLineString = CoffeeComboBox.Items[ListIndexInteger].ToString();
                printLineString = flavor.ToString();
                //Send the line to the graphics page object.
                e.Graphics.DrawString(printLineString, printFont,
                    Brushes.Black, horizontalPrintLocationFloat,
                    verticalPrintLocationFloat);
            } // end for

            //heading for syrup flavours
            verticalPrintLocationFloat += lineHeightFloat*2;

            e.Graphics.DrawString("Syrup Flavours", headingFont,
              Brushes.Black, horizontalPrintLocationFloat,
              verticalPrintLocationFloat);

            //print all syrup flavours
            foreach (Object flavor in syrupListBox.Items)
            {
                //increment the  Y position for the next line.
                verticalPrintLocationFloat += lineHeightFloat;

                //Set up a line
                printLineString = flavor.ToString();
                //Send the line to the graphics page object.
                e.Graphics.DrawString(printLineString, printFont,
                    Brushes.Black, horizontalPrintLocationFloat,
                    verticalPrintLocationFloat);
            } // end for



        }

        private void printSelectedDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            // Handle printing and print previews when printing selected items.

            Font printFont = new Font("Arial", 12);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float lineHeightFloat = printFont.Height + 2;
            float horizontalPrintLocationFloat = e.MarginBounds.Left;
            float verticalPrintLocationFloat = e.MarginBounds.Top;
            string printLineString;

            //Set up and display heading lines
            printLineString = "Print Selected Item";
            e.Graphics.DrawString(printLineString, headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);
            printLineString = "by Anju Chawla";
            verticalPrintLocationFloat += lineHeightFloat;
            e.Graphics.DrawString(printLineString, headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);

            // Leave a blank line between the heading and detail line.
            verticalPrintLocationFloat += lineHeightFloat * 2;
            // Set up the selected line.
            printLineString = "Coffee: " + coffeeComboBox.Text +
                "     Syrup: " + syrupListBox.Text;
            // Send the line to the graphics page object.
            e.Graphics.DrawString(printLineString, printFont,
                Brushes.Black, horizontalPrintLocationFloat,
                  verticalPrintLocationFloat);

    
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //displays the information about the company and application
            AboutForm information = new AboutForm();
            information.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //terminate the application
            Application.Exit();
        }

        private void addCoffeeFlavourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add a new coffee flavour if it already does not exist

            Boolean itemFound = false;
            int itemIndex = 0;

            //if the user has provided a coffee flavour
            if(coffeeComboBox.Text.Trim() != String.Empty )
            {
                //does the flavout already exist
                while(!itemFound && itemIndex < coffeeComboBox.Items.Count )
                {
                    if(coffeeComboBox.Text.Trim().ToUpper() == coffeeComboBox.Items[itemIndex].ToString().Trim().ToUpper())
                    {
                        itemFound = true;
                        
                    }//flavour found
                    else
                    {
                        itemIndex++;
                    }

                }//while

                //if flavour was found
                if(itemFound)
                {
                    MessageBox.Show("Duplicate Flavour cannot be added", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    coffeeComboBox.Text = String.Empty;
                    coffeeComboBox.Focus();
                }
                else
                {
                    //add the flavour
                    coffeeComboBox.Items.Add(coffeeComboBox.Text);
                    coffeeComboBox.Text = String.Empty; 
                }

            }//if flavour provided
            else
            {
                MessageBox.Show("Please provide a coffee flavour to add", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }
        }

        private void removeCoffeeFlavourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove an existing coffee flavour from the list


            //user has put in the coffee flavour text and not a selection from the list
            if(coffeeComboBox.SelectedIndex == -1 && coffeeComboBox.Text != String.Empty )
            {
                //block variables
                Boolean itemFound = false;
                int itemIndex = 0;

                while (!itemFound && itemIndex < coffeeComboBox.Items.Count)
                {
                    if (coffeeComboBox.Text.Trim().ToUpper() == coffeeComboBox.Items[itemIndex].ToString().Trim().ToUpper())
                    {
                        itemFound = true;

                    }//flavour found
                    else
                    {
                        itemIndex++;
                    }

                }//while

                //if flavour found
                if(itemFound)
                {
                    coffeeComboBox.Items.Remove(coffeeComboBox.Text);
                    //coffeeComboBox.Items.RemoveAt(itemIndex);
                    coffeeComboBox.Text = String.Empty;
                    coffeeComboBox.Focus();
                }
                else
                {
                    MessageBox.Show("Coffee flavour to delete does not exist",
                   "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    coffeeComboBox.Text = String.Empty;
                    coffeeComboBox.Focus();
                }

            }
            else if(coffeeComboBox.SelectedIndex != -1)  //user has made a selection
            {
                //coffeeComboBox.Items.Remove(coffeeComboBox.Text);
                //coffeeComboBox.Items.Remove(coffeeComboBox.Items[coffeeComboBox.SelectedIndex]);
                coffeeComboBox.Items.RemoveAt(coffeeComboBox.SelectedIndex);
                coffeeComboBox.Text = String.Empty;
                coffeeComboBox.Focus();
            }
            else //no selection and no text
            {
                MessageBox.Show("Please select or provide the coffee flavour to delete",
                    "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }
        }

        private void clearCoffeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removes all coffee flavours after user confirms

            DialogResult confirm = MessageBox.Show("Delete all coffee flavours?", "Clear Coffee List",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //if user chooses yes
            if(confirm == DialogResult.Yes)
            {
                coffeeComboBox.Items.Clear();
            }
        }

        private void countCoffeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //display the available number of coffee flavours

            String message = "The number of available coffee flavours: " + coffeeComboBox.Items.Count;

            MessageBox.Show(message, "Coffee Flavours", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }
    }
}
