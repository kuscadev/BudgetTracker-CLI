Console.WriteLine("=== Budget Tracker CLI ===");
Console.Write("Enter your monthly income: ");
double income = Convert.ToDouble(Console.ReadLine());
Console.Write("Select currency: (€/$/₺)");
string? currency = Console.ReadLine();

double totalExpense = 0;
string addExpense;

List<(string category, double amount)> expenses = new List<(string, double)>();
do
{
    Console.Write("Enter an expense amount: ");
    double expense = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter the category for this expense (e.g., Food, Rent): ");
    string category = Console.ReadLine();
    expenses.Add((category, expense));


    Console.Write("Do you want to add another expense? (yes/no): ");
    addExpense = Console.ReadLine()?.ToLower();
} while (addExpense == "yes" || addExpense == "y");
totalExpense = expenses.Sum(e => e.amount);
var groupedExpenses = expenses
            .GroupBy(e => e.category)
            .Select(group => new { Category = group.Key, Total = group.Sum(e => e.amount) });

Console.WriteLine("\nExpense Summary by Category:");
foreach (var group in groupedExpenses)
{
    double percent = (group.Total / totalExpense) * 100;
    Console.WriteLine($"{group.Category}: {group.Total} (%{percent:F2})");
}

double monthlySaving = income - totalExpense;

Console.WriteLine("Total Income: " + income + currency);
Console.WriteLine("Total Expense: " + totalExpense + currency);
Console.WriteLine("Monthly Saving: " + monthlySaving + currency);
