namespace ByteBrusher.Util.Resource.Duplicate
{
    public class Duplicate : IDuplicate
    {
        /// </inheritdoc>
        public List<string> SortFiles(List<string> suffixes, List<string> Files)
        {
            List<string> sortedList = new List<string>();
            foreach (string file in Files)
            {
                if (suffixes.Any(suffix => file.EndsWith(suffix)))
                    sortedList.Add(file);
            }
            return sortedList;
        }

        /// <inheritdoc/>
        public List<string> SortList(List<string> suffixes, List<string> files)
        {
            var suffixSet = new HashSet<string>(suffixes);
            return files.Where(file => suffixSet.Any(suffix => file.EndsWith(suffix))).ToList();
        }
    }
}
