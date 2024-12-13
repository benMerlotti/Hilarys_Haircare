import { useEffect, useState } from "react";
import { Table, Button } from "reactstrap";
import { Link } from "react-router-dom";
import { getStylists, toggleStylistStatus } from "../Data/StyilstsData";

export const Stylists = () => {
  const [stylists, setStylists] = useState([]);

  useEffect(() => {
    // Fetch stylists initially
    getStylists().then((data) => {
      setStylists(data);
    });
  }, []);

  const handleToggleStatus = async (id) => {
    try {
      // Optimistically update the stylist status locally
      setStylists((prevStylists) =>
        prevStylists.map((stylist) =>
          stylist.id === id
            ? { ...stylist, isActive: !stylist.isActive }
            : stylist
        )
      );

      // Toggle the status in the database
      await toggleStylistStatus(id);

      // Optionally refetch data if you want to ensure consistency with server
      // const updatedStylists = await getStylists();
      // setStylists(updatedStylists);
    } catch (error) {
      console.error("Error toggling stylist status:", error);
      alert("Failed to toggle stylist status. Please try again.");
    }
  };

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Stylists</h4>
        <Link to="/stylists/create">Add</Link>
      </div>

      {/* Stylists Table */}
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Status</th>
            <th>Actions</th> {/* Combined the buttons */}
          </tr>
        </thead>
        <tbody>
          {stylists.map((s) => (
            <tr key={`stylists-${s.id}`}>
              <th scope="row">{s.id}</th>
              <td>
                {s.firstName} {s.lastName}
              </td>
              <td>{s.email}</td>
              <td>{s.isActive ? "Active" : "Inactive"}</td>
              <td>
                <Link to={`${s.id}`}>Details</Link>
                <Button onClick={() => handleToggleStatus(s.id)}>
                  Toggle Status
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
