import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ScheduleAppointment } from "./Components/ScheduleAppointment";
import { App } from "./App";
import "./index.css";
import { Customers } from "./Components/Customers";
import { Stylists } from "./Components/Stylists";
import { Services } from "./Components/Services";
import { Appointments } from "./Components/Appointments";
import { EditServices } from "./Components/EditServices";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="schedule" element={<ScheduleAppointment />} />
        <Route path="customers" element={<Customers />} />
        <Route path="stylists" element={<Stylists />} />
        <Route path="services" element={<Services />} />
        <Route path="appointments" element={<Appointments />} />
        <Route
          path="appointments/edit-services/:id"
          element={<EditServices />}
        />
      </Route>
    </Routes>
  </BrowserRouter>
);
