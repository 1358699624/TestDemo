using Cmd_Test;

var list = new[] { "甲", "乙", "丙", "丁" };

// 取 2 个一组的所有组合
var result = list.Combinations(2);

foreach (var item in result)
{
    Console.WriteLine(string.Join(",", item));
}

var group1 = new[] { "A", "B" };
var group2 = new[] { "1", "2" };
var group3 = new[] { "X", "Y" };

var allGroups = new List<IEnumerable<object>>
{
    group1, group2, group3
};

var result2 = allGroups.Cartesian();

foreach (var item in result2)
{
    Console.WriteLine(string.Join("-", item));
}