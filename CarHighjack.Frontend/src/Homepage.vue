<template>
  <div class="page">
    <!-- NAV -->
    <nav class="navbar">
      <div class="logo">
        <span class="logo-dot" />
        DriveRent
      </div>
      <ul class="nav-links">
        <li><a href="#">Flota</a></li>
        <li><a href="#">Rezerwacje</a></li>
        <li><a href="#">Cennik</a></li>
        <li><a href="#">Kontakt</a></li>
      </ul>
      <button class="btn-nav">Zaloguj się</button>
    </nav>
 
    <!-- HERO -->
    <section class="hero">
      <div class="hero-text">
        <h1>Jedź tam,<br />gdzie chcesz <em>być.</em></h1>
        <p>
          Wypożycz auto na każdą okazję — od miejskiego kompaktu po premium
          sedan. Szybka rezerwacja, bez ukrytych opłat.
        </p>
        <div class="hero-buttons">
          <button class="btn-primary">Przeglądaj flotę</button>
          <button class="btn-outline">Jak to działa?</button>
        </div>
        <div class="hero-stats">
          <div v-for="stat in stats" :key="stat.label" class="stat-item">
            <div class="stat-num">{{ stat.value }}</div>
            <div class="stat-label">{{ stat.label }}</div>
          </div>
        </div>
      </div>
 
      <div class="hero-visual">
        <div class="car-card">
          <span class="badge-avail">Dostępny</span>
          <div class="car-img-placeholder">
            <CarIllustration />
          </div>
          <div class="car-info">
            <div>
              <div class="car-name">BMW 5 Series</div>
              <div class="car-sub">Premium · Automatik · 2024</div>
            </div>
            <div class="car-price">
              <div class="price-num">320 zł</div>
              <div class="price-unit">za dobę</div>
            </div>
          </div>
        </div>
      </div>
    </section>
 
    <!-- SEARCH BAR -->
    <div class="search-bar">
      <div class="field-group">
        <label>Miejsce odbioru</label>
        <input v-model="search.location" type="text" placeholder="Katowice, ul. Główna 1" />
      </div>
      <div class="field-group">
        <label>Data odbioru</label>
        <input v-model="search.dateFrom" type="date" />
      </div>
      <div class="field-group">
        <label>Data zwrotu</label>
        <input v-model="search.dateTo" type="date" />
      </div>
      <button class="btn-search" @click="handleSearch">
        <i class="ti ti-search" aria-hidden="true" />
        Szukaj
      </button>
    </div>
 
    <!-- FLEET -->
    <section class="fleet-section">
      <div class="section-header">
        <div>
          <div class="section-title">Polecane auta</div>
          <div class="section-sub">Najchętniej wybierane przez klientów</div>
        </div>
        <a class="see-all" href="#">Zobacz wszystkie →</a>
      </div>
      <div class="fleet-grid">
        <FleetCard
          v-for="car in featuredCars"
          :key="car.id"
          :car="car"
          @select="handleCarSelect"
        />
      </div>
    </section>
 
    <!-- WHY US -->
    <div class="why-section">
      <div v-for="item in whyItems" :key="item.title" class="why-item">
        <i :class="`ti ${item.icon}`" aria-hidden="true" />
        <div class="why-title">{{ item.title }}</div>
        <div class="why-desc">{{ item.desc }}</div>
      </div>
    </div>
 
    <!-- FOOTER -->
    <footer>
      <p>© 2025 DriveRent. Wypożyczalnia samochodów.</p>
      <ul class="footer-links">
        <li><a href="#">Regulamin</a></li>
        <li><a href="#">Polityka prywatności</a></li>
        <li><a href="#">Mapa strony</a></li>
      </ul>
    </footer>
  </div>
</template>
 
<script setup lang="ts">
import { reactive } from 'vue'
import FleetCard from './components/FleetCard.vue'
import CarIllustration from './components/CarIllustration.vue'
 
interface Stat {
  value: string
  label: string
}
 
interface Car {
  id: number
  model: string
  type: string
  pricePerDay: number
  seats: number
  tags: string[]
}
 
interface WhyItem {
  icon: string
  title: string
  desc: string
}
 
interface SearchState {
  location: string
  dateFrom: string
  dateTo: string
}
 
const stats: Stat[] = [
  { value: '120+', label: 'Samochodów' },
  { value: '4,8 ★', label: 'Ocena klientów' },
  { value: '24/7', label: 'Wsparcie' },
]
 
import {ref, onMounted } from 'vue'

const featuredCars = ref<Car[]>([])

onMounted(async () => {
  try {
    const response = await fetch('http://localhost:5064/api/Cars')
    const data = await response.json()
    featuredCars.value = data.map((car: any) => ({
      id: car.vin,
      model: `${car.brand} ${car.model}`,
      type: `${car.engine} · ${car.doors} drzwi`,
      pricePerDay: 0,
      seats: car.seatsNumber,
      tags: []
    }))
  } catch (error) {
    console.error('Błąd pobierania aut:', error)
  }
})
 
const whyItems: WhyItem[] = [
  { icon: 'ti-bolt', title: 'Błyskawiczna rezerwacja', desc: 'Zarezerwuj auto w 3 minuty — bez kolejek, bez papierologii.' },
  { icon: 'ti-shield-check', title: 'Pełne ubezpieczenie', desc: 'OC, AC i assistance w cenie. Jedziesz bez stresu.' },
  { icon: 'ti-map-pin', title: 'Odbiór w Twoim miejscu', desc: 'Dostarczymy auto pod wskazany adres na Śląsku.' },
  { icon: 'ti-headset', title: 'Wsparcie całą dobę', desc: 'Zawsze jesteśmy pod telefonem — w dzień i w nocy.' },
]
 
const search = reactive<SearchState>({
  location: '',
  dateFrom: '',
  dateTo: '',
})
 
function handleSearch(): void {
  console.log('Szukam:', search)
  // TODO: nawigacja do strony wyników / wywołanie API
}
 
function handleCarSelect(car: Car): void {
  console.log('Wybrano auto:', car)
  // TODO: nawigacja do strony szczegółów / rezerwacji
}
</script>
 
<style scoped>
@import url('https://fonts.googleapis.com/css2?family=DM+Serif+Display:ital@0;1&family=DM+Sans:wght@300;400;500&display=swap');
 
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
 
.page {
  font-family: 'DM Sans', sans-serif;
  background: #0d0d0d;
  color: #f0ede6;
  min-height: 100vh;
}
 
/* NAV */
.navbar {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1.25rem 2rem;
  border-bottom: 0.5px solid rgba(255, 255, 255, 0.1);
  position: sticky;
  top: 0;
  background: rgba(13, 13, 13, 0.95);
  backdrop-filter: blur(8px);
  z-index: 100;
}
 
.logo {
  font-family: 'DM Serif Display', serif;
  font-size: 1.4rem;
  letter-spacing: -0.02em;
  color: #f0ede6;
  display: flex;
  align-items: center;
  gap: 8px;
}
 
.logo-dot {
  width: 8px;
  height: 8px;
  background: #c9a96e;
  border-radius: 50%;
  display: inline-block;
}
 
.nav-links {
  display: flex;
  gap: 2rem;
  list-style: none;
}
 
.nav-links a {
  color: rgba(240, 237, 230, 0.6);
  text-decoration: none;
  font-size: 0.875rem;
  transition: color 0.2s;
}
 
.nav-links a:hover {
  color: #f0ede6;
}
 
.btn-nav {
  background: #c9a96e;
  color: #0d0d0d;
  border: none;
  padding: 0.5rem 1.25rem;
  border-radius: 100px;
  font-size: 0.875rem;
  font-weight: 500;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
  transition: background 0.2s;
}
 
.btn-nav:hover {
  background: #d4b87a;
}
 
/* HERO */
.hero {
  display: grid;
  grid-template-columns: 1fr 1fr;
  min-height: 560px;
  padding: 4rem 2rem 2rem;
  gap: 3rem;
  align-items: center;
}
 
.hero-text h1 {
  font-family: 'DM Serif Display', serif;
  font-size: clamp(2.5rem, 5vw, 4rem);
  line-height: 1.08;
  letter-spacing: -0.03em;
  margin-bottom: 1.25rem;
}
 
.hero-text h1 em {
  font-style: italic;
  color: #c9a96e;
}
 
.hero-text p {
  font-size: 1rem;
  color: rgba(240, 237, 230, 0.55);
  line-height: 1.7;
  max-width: 38ch;
  margin-bottom: 2rem;
  font-weight: 300;
}
 
.hero-buttons {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}
 
.btn-primary {
  background: #c9a96e;
  color: #0d0d0d;
  border: none;
  padding: 0.875rem 2rem;
  border-radius: 100px;
  font-size: 0.9rem;
  font-weight: 500;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
  transition: background 0.2s;
}
 
.btn-primary:hover {
  background: #d4b87a;
}
 
.btn-outline {
  background: transparent;
  color: #f0ede6;
  border: 0.5px solid rgba(240, 237, 230, 0.35);
  padding: 0.875rem 2rem;
  border-radius: 100px;
  font-size: 0.9rem;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
  transition: border-color 0.2s;
}
 
.btn-outline:hover {
  border-color: rgba(240, 237, 230, 0.7);
}
 
.hero-stats {
  display: flex;
  gap: 2rem;
  margin-top: 2.5rem;
}
 
.stat-num {
  font-family: 'DM Serif Display', serif;
  font-size: 1.75rem;
  line-height: 1;
}
 
.stat-label {
  font-size: 0.75rem;
  color: rgba(240, 237, 230, 0.45);
  text-transform: uppercase;
  letter-spacing: 0.08em;
  margin-top: 3px;
}
 
/* HERO CARD */
.hero-visual {
  height: 360px;
}
 
.car-card {
  background: #1a1a1a;
  border: 0.5px solid rgba(255, 255, 255, 0.1);
  border-radius: 16px;
  overflow: hidden;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  padding: 1.5rem;
  position: relative;
}
 
.car-img-placeholder {
  position: absolute;
  inset: 0;
  display: flex;
  align-items: center;
  justify-content: center;
}
 
.badge-avail {
  position: absolute;
  top: 1rem;
  right: 1rem;
  background: rgba(40, 140, 80, 0.2);
  border: 0.5px solid rgba(40, 180, 80, 0.3);
  color: #6de89a;
  font-size: 0.7rem;
  padding: 4px 10px;
  border-radius: 100px;
  z-index: 2;
}
 
.car-info {
  position: relative;
  z-index: 2;
  background: rgba(13, 13, 13, 0.75);
  border: 0.5px solid rgba(255, 255, 255, 0.1);
  border-radius: 12px;
  padding: 1rem 1.25rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
 
.car-name {
  font-family: 'DM Serif Display', serif;
  font-size: 1.1rem;
}
 
.car-sub {
  font-size: 0.75rem;
  color: rgba(240, 237, 230, 0.45);
  margin-top: 2px;
}
 
.price-num {
  font-size: 1.3rem;
  font-weight: 500;
  color: #c9a96e;
}
 
.price-unit {
  font-size: 0.7rem;
  color: rgba(240, 237, 230, 0.4);
  text-align: right;
}
 
/* SEARCH BAR */
.search-bar {
  margin: 0 2rem 3rem;
  background: #161616;
  border: 0.5px solid rgba(255, 255, 255, 0.12);
  border-radius: 16px;
  padding: 1.25rem 1.5rem;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr auto;
  gap: 1rem;
  align-items: end;
}
 
.field-group label {
  display: block;
  font-size: 0.7rem;
  color: rgba(240, 237, 230, 0.4);
  text-transform: uppercase;
  letter-spacing: 0.07em;
  margin-bottom: 6px;
}
 
.field-group input {
  width: 100%;
  background: rgba(255, 255, 255, 0.05);
  border: 0.5px solid rgba(255, 255, 255, 0.12);
  border-radius: 8px;
  padding: 0.6rem 0.875rem;
  color: #f0ede6;
  font-family: 'DM Sans', sans-serif;
  font-size: 0.875rem;
  outline: none;
  transition: border-color 0.2s;
}
 
.field-group input:focus {
  border-color: rgba(201, 169, 110, 0.5);
}
 
.field-group input::placeholder {
  color: rgba(240, 237, 230, 0.3);
}
 
.btn-search {
  background: #c9a96e;
  color: #0d0d0d;
  border: none;
  padding: 0.65rem 1.5rem;
  border-radius: 8px;
  font-size: 0.875rem;
  font-weight: 500;
  cursor: pointer;
  font-family: 'DM Sans', sans-serif;
  display: flex;
  align-items: center;
  gap: 6px;
  white-space: nowrap;
  transition: background 0.2s;
}
 
.btn-search:hover {
  background: #d4b87a;
}
 
/* FLEET */
.fleet-section {
  padding: 2rem 2rem 3rem;
}
 
.section-header {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  margin-bottom: 1.5rem;
}
 
.section-title {
  font-family: 'DM Serif Display', serif;
  font-size: 1.75rem;
  letter-spacing: -0.02em;
}
 
.section-sub {
  font-size: 0.8rem;
  color: rgba(240, 237, 230, 0.4);
  margin-top: 4px;
}
 
.see-all {
  color: #c9a96e;
  font-size: 0.85rem;
  text-decoration: none;
  font-weight: 500;
}
 
.fleet-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
}
 
/* WHY */
.why-section {
  margin: 1rem 2rem 3rem;
  background: #141414;
  border: 0.5px solid rgba(255, 255, 255, 0.08);
  border-radius: 20px;
  padding: 2.5rem;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 2rem;
}
 
.why-item i {
  font-size: 24px;
  color: #c9a96e;
  margin-bottom: 0.75rem;
  display: block;
}
 
.why-title {
  font-weight: 500;
  font-size: 0.95rem;
  margin-bottom: 6px;
}
 
.why-desc {
  font-size: 0.8rem;
  color: rgba(240, 237, 230, 0.4);
  line-height: 1.6;
  font-weight: 300;
}
 
/* FOOTER */
footer {
  border-top: 0.5px solid rgba(255, 255, 255, 0.08);
  padding: 1.5rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
 
footer p {
  font-size: 0.75rem;
  color: rgba(240, 237, 230, 0.3);
}
 
.footer-links {
  display: flex;
  gap: 1.5rem;
  list-style: none;
}
 
.footer-links a {
  font-size: 0.75rem;
  color: rgba(240, 237, 230, 0.35);
  text-decoration: none;
}
</style>