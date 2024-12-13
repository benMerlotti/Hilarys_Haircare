import { useEffect, useState } from "react";
import { Table } from "reactstrap";
import { Link } from "react-router-dom";
import { getCustomers } from "../Data/CustomersData";

export const Customers = () => {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    // Fetch stylists initially
    getCustomers().then((data) => {
      setCustomers(data);
    });
  }, []);

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Customers</h4>
        <Link to="/customers/create">Add</Link>
      </div>

      {/* Stylists Table */}
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((s) => (
            <tr key={`stylists-${s.id}`}>
              <th scope="row">{s.id}</th>
              <td>
                {s.firstName} {s.lastName}
              </td>
              <td>{s.email}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
