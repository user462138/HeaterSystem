using Moq;

namespace HeaterSystem.UnitTests
{
    [TestClass]
    public class ThermostatTests
    {
        private Mock<ITemperatureSensor> temperatureSensorMock = null;
        private Mock<IHeatingElement> heatingElementMock = null;

        private Thermostat thermostat = null;


        [TestInitialize()]
        public void Initialize()
        {
            // Mock the objects used by the Thermostat object
            temperatureSensorMock = new Mock<ITemperatureSensor>();
            heatingElementMock = new Mock<IHeatingElement>();

            // Create the test object
            thermostat = new Thermostat(temperatureSensorMock.Object, heatingElementMock.Object)
            {
                // Set the setpoint and offset
                Setpoint = 20.0,
                Offset = 2.0
            };
        }

        [TestMethod]
        public void WorkWhenTemperatureBetweenBoundariesDoNothing()
        {
            // Configure the mock object to get the temperature between boundaries = 19.0
            temperatureSensorMock.Setup(x => x.GetTemperature()).Returns(19.0);
        }

        
        [TestMethod]
        public void WorkWhenTemperatureLessThanLowerBoundaryEnableHeatingElement()
        {
            // Configure the mock object to get the temperature less than lower boundary = 17.0
            temperatureSensorMock.Setup(x => x.GetTemperature()).Returns(17.0);
        }
    }
}