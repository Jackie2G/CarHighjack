<template>
  <div class="page">
    <nav class="navbar">
      <div class="logo">
        <span class="logo-dot" />
        DriveRent
      </div>
      <button class="btn-nav" @click="goBack">← Wróć</button>
    </nav>

    <div class="form-container">
      <h1 class="form-title">Dodaj nowe auto</h1>

      <div class="form-grid">
        <div class="field-group">
          <label>VIN (17 znaków)</label>
          <input v-model="car.vin" type="text" placeholder="np. WVWZZZ1KZAM123456" maxlength="17" />
        </div>
        <div class="field-group">
          <label>Numer rejestracyjny</label>
          <input v-model="car.registrationNumber" type="text" placeholder="np. KR12345" />
        </div>
        <div class="field-group">
          <label>Marka</label>
          <input v-model="car.brand" type="text" placeholder="np. Toyota" />
        </div>
        <div class="field-group">
          <label>Model</label>
          <input v-model="car.model" type="text" placeholder="np. Corolla" />
        </div>
        <div class="field-group">
          <label>Liczba miejsc</label>
          <input v-model.number="car.seatsNumber" type="number" min="1" max="9" />
        </div>
        <div class="field-group">
          <label>Liczba drzwi</label>
          <input v-model.number="car.doors" type="number" min="2" max="5" />
        </div>
        <div class="field-group">
          <label>Pojemność bagażnika (L)</label>
          <input v-model.number="car.trunk" type="number" min="1" />
        </div>
        <div class="field-group">
          <label>Moc silnika (KM)</label>
          <input v-model.number="car.horsePower" type="number" min="1" />
        </div>
        <div class="field-group">
          <label>Silnik</label>
          <input v-model="car.engine" type="text" placeholder="np. 1.6 Benzyna" />
        </div>
        <div class="field-group">
          <label>Rozmiar opon</label>
          <input v-model="car.tyreSize" type="text" placeholder="np. 205/55R16" />
        </div>
        <div class="field-group">
          <label>Data ubezpieczenia</label>
          <input v-model="car.insurance" type="date" />
        </div>
        <div class="field-group">
          <label>Data przeglądu technicznego</label>
          <input v-model="car.technicalReview" type="date" />
        </div>
      </div>

      <div v-if="errorMessage" class="error-msg">{{ errorMessage }}</div>
      <div v-if="successMessage" class="success-msg">{{ successMessage }}</div>

      <button class="btn-submit" @click="addCar" :disabled="loading">
        {{ loading ? 'Dodawanie...' : 'Dodaj auto' }}
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const loading = ref(false)
const errorMessage = ref('')
const successMessage = ref('')

const car = ref({
  vin: '',
  registrationNumber: '',
  brand: '',
  model: '',
  seatsNumber: 5,
  doors: 4,
  trunk: 300,
  horsePower: 100,
  engine: '',
  tyreSize: '',
  fuel: 1,
  cardPin: '',
  insurance: '',
  technicalReview: '',
  photoPath: null
})

async function addCar() {
  errorMessage.value = ''
  successMessage.value = ''

  if (!car.value.vin || car.value.vin.length !== 17) {
    errorMessage.value = 'VIN musi mieć dokładnie 17 znaków!'
    return
  }
  if (!car.value.brand || !car.value.model) {
    errorMessage.value = 'Marka i model są wymagane!'
    return
  }

  loading.value = true
  try {
    const response = await fetch('http://localhost:5064/api/Cars', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        ...car.value,
        insurance: car.value.insurance + 'T00:00:00',
        technicalReview: car.value.technicalReview + 'T00:00:00'
      })
    })

    if (response.ok) {
      successMessage.value = 'Auto zostało dodane pomyślnie!'
      car.value.vin = ''
      car.value.brand = ''
      car.value.model = ''
      car.value.registrationNumber = ''
    } else {
      errorMessage.value = 'Błąd podczas dodawania auta!'
    }
  } catch (error) {
    errorMessage.value = 'Nie można połączyć się z serwerem!'
  }
  loading.value = false
}

function goBack() {
  window.history.back()
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=DM+Serif+Display:ital@0;1&family=DM+Sans:wght@300;400;500&display=swap');

* { box-sizing: border-box; margin: 0; padding: 0; }

.page {
  font-family: 'DM Sans', sans-serif;
  background: #0d0d0d;
  color: #f0ede6;
  min-height: 100vh;
}

.navbar {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1.25rem 2rem;
  border-bottom: 0.5px solid rgba(255,255,255,0.1);
  background: rgba(13,13,13,0.95);
}

.logo {
  font-family: 'DM Serif Display', serif;
  font-size: 1.4rem;
  display: flex;
  align-items: center;
  gap: 8px;
}

.logo-dot {
  width: 8px; height: 8px;
  background: #c9a96e;
  border-radius: 50%;
  display: inline-block;
}

.btn-nav {
  background: transparent;
  color: #f0ede6;
  border: 0.5px solid rgba(240,237,230,0.35);
  padding: 0.5rem 1.25rem;
  border-radius: 100px;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
}

.form-container {
  max-width: 800px;
  margin: 3rem auto;
  padding: 0 2rem;
}

.form-title {
  font-family: 'DM Serif Display', serif;
  font-size: 2rem;
  margin-bottom: 2rem;
}

.form-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1.25rem;
  margin-bottom: 1.5rem;
}

.field-group label {
  display: block;
  font-size: 0.75rem;
  color: rgba(240,237,230,0.4);
  text-transform: uppercase;
  letter-spacing: 0.07em;
  margin-bottom: 6px;
}

.field-group input {
  width: 100%;
  background: rgba(255,255,255,0.05);
  border: 0.5px solid rgba(255,255,255,0.12);
  border-radius: 8px;
  padding: 0.6rem 0.875rem;
  color: #f0ede6;
  font-family: 'DM Sans', sans-serif;
  font-size: 0.875rem;
  outline: none;
}

.field-group input:focus {
  border-color: rgba(201,169,110,0.5);
}

.btn-submit {
  background: #c9a96e;
  color: #0d0d0d;
  border: none;
  padding: 0.875rem 2rem;
  border-radius: 100px;
  font-size: 0.9rem;
  font-weight: 500;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
  width: 100%;
  margin-top: 1rem;
}

.btn-submit:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.error-msg {
  background: rgba(255,50,50,0.1);
  border: 0.5px solid rgba(255,50,50,0.3);
  color: #ff6b6b;
  padding: 0.75rem 1rem;
  border-radius: 8px;
  margin-bottom: 1rem;
}

.success-msg {
  background: rgba(40,180,80,0.1);
  border: 0.5px solid rgba(40,180,80,0.3);
  color: #6de89a;
  padding: 0.75rem 1rem;
  border-radius: 8px;
  margin-bottom: 1rem;
}
</style>