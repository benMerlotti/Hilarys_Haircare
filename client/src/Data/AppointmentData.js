const _apiUrl = "https://localhost:5001"

export const getAppointments = () => {
    return fetch(`${_apiUrl}/appointments`).then((r)=> r.json())
}

export const createAppointment = (appointment) => {
    return fetch(`${_apiUrl}/schedule-appointment`, {
        method: "POST",
        headers: { "Content-Type" : "application/json" },
        body: JSON.stringify(appointment)
    }).then((r)=> r.json())
}

export const toggleApp = (id) => {
    return fetch(`${_apiUrl}/toggle-status/${id}`, {
        method: "PUT",
        headers: { "Content-Type" : "application/json" }
    }).then((r)=> r.json())
}

export const editAppointmentServices = (updatedRequest) => {
    return fetch(`${_apiUrl}/edit-services`, {
        method: "PUT",
        headers: { "Content-Type" : "application/json" },
        body: JSON.stringify(updatedRequest)
    }).then((r)=> r.json())
}