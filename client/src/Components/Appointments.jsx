import { useEffect, useState } from "react";
import { Button, Table } from "reactstrap";
import { getAppointments, toggleApp } from "../Data/AppointmentData";
import { useNavigate } from "react-router-dom";

export const Appointments = () => {
  const [appointments, setAppointments] = useState([]);
  const [shouldRefetch, setShouldRefetch] = useState(false); // Track re-fetch trigger

  const navigate = useNavigate();
  // Fetch appointments whenever `shouldRefetch` changes
  useEffect(() => {
    const fetchAppointments = async () => {
      const appointmentsData = await getAppointments();
      setAppointments(appointmentsData);
    };

    fetchAppointments();
  }, [shouldRefetch]); // Trigger fetch when `shouldRefetch` changes

  // This function can be called to trigger a re-fetch
  const triggerRefetch = () => {
    setShouldRefetch(!shouldRefetch); // Toggle the state to trigger re-fetch
  };

  const handleToggleStatus = (id) => {
    toggleApp(id).then(() => {
      getAppointments().then((data) => {
        setAppointments(data);
      });
    });
  };

  const handleEditServices = (id) => {
    navigate(`edit-services/${id}`);
  };

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Appointments</h4>
        {/* Trigger refetch when a new appointment is created */}
        <button onClick={triggerRefetch}>Refetch Appointments</button>
      </div>
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Customer</th>
            <th>Stylist</th>
            <th>Service</th>
            <th>Total Cost</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {appointments.map((a) => (
            <tr key={`checkouts-${a.id}`}>
              <th scope="row">{a.id}</th>
              <td>
                {a.customer.firstName} {a.customer.lastName}
              </td>
              <td>
                {a.stylist.firstName} {a.stylist.lastName}
              </td>
              <td>
                {a.services.map((s) => `${s.name} `).join(", ")}
                <Button onClick={() => handleEditServices(a.id)}>Edit</Button>
              </td>
              <td>{`$${a.totalCost}`}</td>
              <td>{a.isCancelled ? "Cancelled" : "As booked"}</td>
              <Button onClick={() => handleToggleStatus(a.id, a.services)}>
                {a.isCancelled ? "Re-book" : "Cancel"}
              </Button>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
