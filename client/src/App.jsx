import "bootstrap/dist/css/bootstrap.css";
import { Outlet } from "react-router-dom";
import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import "./App.css";
export const App = () => {
  return (
    <>
      <Navbar color="info" expand="md">
        <Nav navbar>
          <NavbarBrand href="/">Hilarys HairCare</NavbarBrand>
          <NavItem>
            <NavLink href="/schedule">Schedule Appointment</NavLink>
            <NavLink href="/customers">Customers</NavLink>
            <NavLink href="/stylists">Stylists</NavLink>
            <NavLink href="/services">Services</NavLink>
            <NavLink href="/appointments">Appointments</NavLink>
          </NavItem>
        </Nav>
      </Navbar>
      <Outlet />
    </>
  );
};
