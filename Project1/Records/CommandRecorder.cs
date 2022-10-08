using System.IO;

namespace Zelda.Records
{
    // clearing + appending data reference: https://stackoverflow.com/questions/5516870/how-to-write-data-to-a-text-file-without-overwriting-the-current-data
    public class CommandRecorder
    {
        private readonly string _filename;
        public CommandRecorder(string filename)
        {
            _filename = FilePathFinder.FindFilePath("Records", filename);
            TextWriter textWriter = new StreamWriter(_filename, false);
            textWriter.Close();            
        }

        public void RecordCommand(string command)
        {
            TextWriter textWriter = new StreamWriter(_filename, true);
            textWriter.WriteLine(command);
            textWriter.Close();
        }

    }
}
