namespace UdemyCarBook.Dto.ReservationDtos;

public class CreateReservationDto
{
    public int CarID { get; set; }
    public int Name { get; set; }
    public int Surname { get; set; }
    public int Email { get; set; }
    public int Phone { get; set; }
    public int Age { get; set; }
    public int DriverLicenseYear { get; set; }
    public int Description { get; set; }

}
