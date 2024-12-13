import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getServices } from "../Data/ServicesData";
import {
  editAppointmentServices,
  getAppointments,
} from "../Data/AppointmentData";
import { Button, FormGroup, Input, Label } from "reactstrap";

export const EditServices = () => {
  const navigate = useNavigate();
  const { id } = useParams();

  const [appointments, setAppointments] = useState([]);
  const [services, setServices] = useState([]);
  const [selectedServices, setSelectedServices] = useState([]);

  useEffect(() => {
    getServices().then(setServices);
  }, []);

  useEffect(() => {
    getAppointments().then(setAppointments);
  }, []);

  const handleServiceChange = (event) => {
    const serviceId = Number(event.target.value); // Convert value to a number
    setSelectedServices((prevSelectedServices) => {
      if (prevSelectedServices.includes(serviceId)) {
        // Remove the service if already selected
        return prevSelectedServices.filter((id) => id !== serviceId);
      } else {
        // Add the service if not selected
        return [...prevSelectedServices, serviceId];
      }
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault(); // Prevent the form from refreshing the page
    const app = appointments.find((a) => a.id === Number(id));

    if (app) {
      let updatedRequest = {
        id: parseInt(id),
        services: selectedServices, // selectedServices should be an array of IDs
      };

      console.log(updatedRequest); // Logs the data being sent
      editAppointmentServices(updatedRequest);

      navigate("/appointments", { state: { refetch: true } });
    }
  };

  return (
    <div className="container">
      <h1>Edit Service</h1>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="services">Select Services</Label>
          <div id="services">
            {services.map((service) => (
              <div key={service.id}>
                <Input
                  type="checkbox"
                  value={service.id}
                  checked={selectedServices.includes(service.id)}
                  onChange={handleServiceChange}
                  id={`service-${service.id}`}
                />
                <Label for={`service-${service.id}`} className="ml-2">
                  {service.name}
                </Label>
              </div>
            ))}
          </div>
        </FormGroup>
        <Button type="submit">Book your appointment</Button>
      </form>
    </div>
  );
};
