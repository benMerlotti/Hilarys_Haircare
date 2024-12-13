import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getCustomers } from "../Data/CustomersData";
import { getStylists } from "../Data/StyilstsData";
import { getServices } from "../Data/ServicesData";
import { createAppointment } from "../Data/AppointmentData";
import { useNavigate } from "react-router-dom";

export const ScheduleAppointment = () => {
  const [customers, setCustomers] = useState([]);
  const [stylists, setStylists] = useState([]);
  const [services, setServices] = useState([]);
  const [dates, setDates] = useState([]);
  const [times, setTimes] = useState([]);
  const [selectedServices, setSelectedServices] = useState([]);
  const [formData, setFormData] = useState({
    customerId: "",
    stylistId: "",
    date: "",
    time: "",
  });

  const navigate = useNavigate();

  const generateDates = () => {
    const today = new Date();
    const datesArray = [];
    for (let i = 0; i < 7; i++) {
      const futureDate = new Date(today);
      futureDate.setDate(today.getDate() + i);
      datesArray.push({
        display: futureDate.toLocaleDateString("en-US", {
          weekday: "long",
          year: "numeric",
          month: "long",
          day: "numeric",
        }),
        value: futureDate.toISOString().split("T")[0], // Backend-friendly format (YYYY-MM-DD)
      });
    }
    setDates(datesArray);
  };

  const generateTimes = () => {
    const timesArray = [];
    for (let hour = 9; hour <= 17; hour++) {
      const time = new Date();
      time.setHours(hour);
      time.setMinutes(0);
      timesArray.push({
        display: time.toLocaleTimeString("en-US", {
          hour: "2-digit",
          minute: "2-digit",
        }),
        value: time.toISOString().split("T")[1].substring(0, 5), // Backend-friendly format (HH:mm)
      });
    }
    setTimes(timesArray);
  };

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

  useEffect(() => {
    generateDates();
    generateTimes();
  }, []);

  useEffect(() => {
    getCustomers().then(setCustomers);
  }, []);

  useEffect(() => {
    getStylists().then(setStylists);
  }, []);

  useEffect(() => {
    getServices().then(setServices);
  }, []);

  const handleSubmit = () => {
    const scheduledTime = `${formData.date}T${formData.time}:00`;

    const serviceDetails = services
      .filter((s) => selectedServices.includes(s.id))
      .map((s) => ({
        id: s.id,
      }));

    const appointmentData = {
      customerId: parseInt(formData.customerId),
      stylistId: parseInt(formData.stylistId),
      services: serviceDetails,
      scheduledTime: scheduledTime,
    };

    createAppointment(appointmentData).then(() =>
      navigate("/appointments", { state: { refetch: true } })
    );
  };

  return (
    <div className="container">
      <h1>Book an Appointment</h1>
      <Form>
        <FormGroup>
          <Label>Customer</Label>
          <Input
            name="customerId"
            type="select"
            value={formData.customerId}
            onChange={(e) => {
              const formCopy = { ...formData };
              formCopy.customerId = e.target.value;
              setFormData(formCopy);
            }}
          >
            <option value="">Choose a customer</option>
            {customers.map((c) => (
              <option key={c.id} value={c.id}>
                {c.firstName} {c.lastName}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Stylist</Label>
          <Input
            name="stylistId"
            type="select"
            value={formData.stylistId}
            onChange={(e) => {
              const formCopy = { ...formData };
              formCopy.stylistId = e.target.value;
              setFormData(formCopy);
            }}
          >
            <option value="">Choose a Stylist</option>
            {stylists.map((s) => (
              <option key={s.id} value={s.id}>
                {s.firstName} {s.lastName}
              </option>
            ))}
          </Input>
        </FormGroup>
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
        <FormGroup>
          <Label>Date</Label>
          <Input
            name="date"
            type="select"
            value={formData.date}
            onChange={(e) => {
              const formCopy = { ...formData };
              formCopy.date = e.target.value;
              setFormData(formCopy);
            }}
          >
            <option value="">Choose a Date</option>
            {dates.map((d) => (
              <option key={d.value} value={d.value}>
                {d.display}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Time</Label>
          <Input
            name="time"
            type="select"
            value={formData.time}
            onChange={(e) => {
              const formCopy = { ...formData };
              formCopy.time = e.target.value;
              setFormData(formCopy);
            }}
          >
            <option value="">Choose a Time</option>
            {times.map((t) => (
              <option key={t.value} value={t.value}>
                {t.display}
              </option>
            ))}
          </Input>
        </FormGroup>
      </Form>
      <Button onClick={handleSubmit}>Book your appointment</Button>
    </div>
  );
};
