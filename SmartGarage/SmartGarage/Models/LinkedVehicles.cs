using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartGarage.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LinkedVehicles
{
    [Key]
    public int LinkedVehicleID { get; set; }

    [Required]
    [ForeignKey("Model")]
    public int ModelID { get; set; }
    public CarModel Model { get; set; }

    [Required]
    [ForeignKey("Manufacturer")]
    public int ManufacturerID { get; set; }
    public Manufacturer Manufacturer { get; set; }

    [Required]
    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }
    public Employee Employee { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(8)] //supports only bulgarian license plates
    [RegularExpression(@"^(A|B|BH|BP|BT|E|EB|EH|K|KH|M|H|OB|P|PA|PB|PK|PP|C|CA|CB|CH|CM|CO|CC|CT|T|TX|Y|X|EA) \d{1,4} (А|В|Е|К|М|Н|О|Р|С|Т|У|Х){1,2}$", ErrorMessage = "Invalid license plate format.")]
    public string LicensePlate { get; set; }

    [Required]
    [StringLength(17)]
    public string VIN { get; set; }

    [Required]
    [Range(1887, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1887.")]
    public int YearOfCreation { get; set; }

    [Required]
    [ForeignKey("Invoice")]
    public int InvoiceID { get; set; }
    public Invoice Invoice { get; set; }

    // Navigation property for services associated with this linked vehicle
    public ICollection<LinkedVehicleService> LinkedVehicleServices { get; set; }
}
