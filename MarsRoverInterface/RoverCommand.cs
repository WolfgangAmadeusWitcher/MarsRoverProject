using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MarsRoverInterface.Models;

namespace MarsRoverInterface
{
    public partial class RoverCommand : Form
    {
        public List<Rover> DeployedRovers { get; set; }
        public string[] RawUserInputs { get; private set; }

        private readonly Plane _marsPlane = new Plane();

        public RoverCommand()
        {
            DeployedRovers = new List<Rover>();
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            txtBoxOutput.Text = string.Empty;
            gridRoverLog.Rows.Clear();
            gridRoverLog.Refresh();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GetInputFromFile(openFileDialog.FileName);
                }
            }
        }

        private void GetInputFromFile(string path)
        {
            RawUserInputs = File.ReadAllLines(path).Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();

            if (!RawUserInputs.Any())
            {
                MessageBox.Show(@"Input File You've selected is Empty : " + path, @"Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (RawUserInputs == null)
            {
                MessageBox.Show(@"Please Select a valid Input File Before Processing", @"Processing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = InitializePlane();

            if (!success)
            {
                RawUserInputs = null;
                return;
            }

            for (int i = 1; i < RawUserInputs.Length; i += 2)
            {
                if (i + 1 >= RawUserInputs.Length)
                {
                    MessageBox.Show(@"Imported File at line " + i + @" does not contain Command List Missing For Rover : ", @"Rover Deployment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                AddNewRover(RawUserInputs[i], RawUserInputs[i + 1], i + 1);
            }
            DisplayOutput();
            RawUserInputs = null;
            DeployedRovers = new List<Rover>();
        }

        private bool InitializePlane()
        {
            try
            {
                _marsPlane.ParseUserInput(RawUserInputs[0]);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Invalid Plane Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void AddNewRover(string orientationInput, string commandInput, int lineNum)
        {
            try
            {
                var rover = new Rover(DeployedRovers.Count + 1);
                rover.DeployRover(orientationInput, _marsPlane);
                rover.ProcessUserCommands(commandInput, _marsPlane);
                DeployedRovers.Add(rover);
                WriteRoverLogsToGrid(rover);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + @" At line : " + lineNum, @"Rover Deployment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WriteRoverLogsToGrid(Rover rover)
        {
            foreach (var logEntry in rover.RoverLog)
            {
                object[] newEntry = { rover.Id.ToString(), logEntry };
                gridRoverLog.Rows.Add(newEntry);
            }
        }

        private void DisplayOutput()
        {
            foreach (var rover in DeployedRovers)
            {
                txtBoxOutput.AppendText(rover.GetOrientationResult());
                txtBoxOutput.AppendText(Environment.NewLine);
            }
        }
    }
}
