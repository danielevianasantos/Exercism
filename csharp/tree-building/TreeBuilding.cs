using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; } = new List<Tree>();

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        if (records.Count() != 0)
        {
            var trees = new List<Tree>();
            var previousRecordId = 0;
            records = records.OrderBy(item => item.RecordId);
            foreach (var record in records)
            {
                var t = new Tree { Id = record.RecordId, ParentId = record.ParentId };
                trees.Add(t);

                if (Validate(t))
                {
                    throw new ArgumentException();
                }

                previousRecordId++;
            }

            for (int i = 1; i < trees.Count; i++)
            {
                var t = trees.First(x => x.Id == i);
                var parent = trees.First(x => x.Id == t.ParentId);
                parent.Children.Add(t);
            }

            var r = trees.First(t => t.Id == 0);
            return r;
        }

        throw new ArgumentException("Error");
    }
    public static bool Validate(Tree t)
    {
        if ((t.Id == 0 && t.ParentId != 0) ||
            (t.Id != 0 && t.ParentId >= t.Id) ||
            (t.Id != 0 && t.Id != t.Id-1))
        {
            return true;
        }
        return false;
    }
}