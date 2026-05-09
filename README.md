# Training Center API

REST API do zarządzania salami szkoleniowymi i rezerwacjami.

## Endpointy

### Sale (`/api/rooms`)

| Metoda | Endpoint | Opis |
|--------|----------|------|
| GET | `/api/rooms` | Lista wszystkich sal (filtry: `minCapacity`, `hasProjector`, `activeOnly`) |
| GET | `/api/rooms/{id}` | Sala po id |
| GET | `/api/rooms/building/{buildingCode}` | Sale z danego budynku |
| POST | `/api/rooms` | Dodaj salę |
| PUT | `/api/rooms/{id}` | Zaktualizuj salę |
| DELETE | `/api/rooms/{id}` | Usuń salę |

### Rezerwacje (`/api/reservations`)

| Metoda | Endpoint | Opis |
|--------|----------|------|
| GET | `/api/reservations` | Lista rezerwacji (filtry: `date`, `status`, `roomId`) |
| GET | `/api/reservations/{id}` | Rezerwacja po id |
| POST | `/api/reservations` | Dodaj rezerwację |
| PUT | `/api/reservations/{id}` | Zaktualizuj rezerwację |
| DELETE | `/api/reservations/{id}` | Usuń rezerwację |

## Przykładowe żądania

**POST /api/rooms**
```json
{
  "name": "Lab 204",
  "buildingCode": "B",
  "floor": 2,
  "capacity": 24,
  "hasProjector": true,
  "isActive": true
}
```

**POST /api/reservations**
```json
{
  "roomId": 2,
  "organizerName": "Anna Kowalska",
  "topic": "Warsztaty z HTTP i REST",
  "date": "2026-05-10",
  "startTime": "10:00:00",
  "endTime": "12:30:00",
  "status": "Planned"
}
```
