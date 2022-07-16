const endpoint = "https://localhost:7020"

export async function GetUserList() {
    return await fetch(`${endpoint}/api/User/Index`).then(response => response.json())
}

export async function GetDetail(id) {
    return await fetch(`${endpoint}/api/User/GetDetail?id=${id}`).then(response => response.json())
}

export async function Delete(id) {
    return await fetch(`${endpoint}/api/User/Delete?id=${id}`, { method: 'DELETE', }).then(response => response.json())
}

export async function InsertOrUpdate(item) {
    return await fetch(`${endpoint}/api/User/InsertOrUpdate`,
        {
            headers: {
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(item)
        })
        .then(response => response.json())
}