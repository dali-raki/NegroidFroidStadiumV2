using Microsoft.AspNetCore.Components;
using NUnit.Framework;
using UltimateStadium.Services;




[TestFixture]

public class StadiumTest
{
    [Inject] public IStadiumService stadiumService{get; set; }
    [Inject] public IUserService userService{get; set; }
    
    
    
    [Test]
    public  async Task  reserveTest()
    {
        var isReserved = false;
        try
        {
           isReserved= await stadiumService.addNewStadium("Gogo","Biskra",5000);
           Assert.Equals(isReserved,false);
        }
        catch (Exception e)
        {
                Console.WriteLine(e);
        }
  
    }
    
    
       
    [Test]
    public async Task  loginTest()
    {
        try
        {
            var (email,role,password)=await  userService.AuthenticateUser("raki@gmail.com", "123");


            Assert.Equals("raki@gmail.com", email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
   
    }
    
    
    
       
    [Test]
    public async Task  paymentTest()
    {
        // Not Ready
    }
    
    
       
    [Test]
    public async Task  getFav()
    {
        
        try
        {
            var list = await stadiumService.getfav();
            Assert.Equals(list,null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    
    
}