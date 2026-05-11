<template>
  <div class="fleet-card" @click="$emit('select', car)">
    <div class="fleet-img">
      <slot name="image">
        <svg viewBox="0 0 260 110" width="200" fill="none" xmlns="http://www.w3.org/2000/svg">
          <rect x="20" y="55" width="220" height="35" rx="8" fill="#252525" />
          <path d="M40 55 C40 55, 70 20, 105 16 L155 16 C190 16, 220 35, 225 55 Z" fill="#1e1e1e" />
          <rect x="62" y="23" width="48" height="30" rx="3" fill="#1a3a5c" opacity="0.7" />
          <rect x="118" y="23" width="64" height="30" rx="3" fill="#1a3a5c" opacity="0.7" />
          <circle cx="70" cy="90" r="16" fill="#111" />
          <circle cx="70" cy="90" r="10" fill="#1e1e1e" />
          <circle cx="70" cy="90" r="4" fill="#c9a96e" opacity="0.6" />
          <circle cx="190" cy="90" r="16" fill="#111" />
          <circle cx="190" cy="90" r="10" fill="#1e1e1e" />
          <circle cx="190" cy="90" r="4" fill="#c9a96e" opacity="0.6" />
          <rect x="22" y="62" width="32" height="12" rx="5" fill="#c9a96e" opacity="0.5" />
        </svg>
      </slot>
    </div>
    <div class="fleet-body">
      <div class="fleet-model">{{ car.model }}</div>
      <div class="fleet-type">{{ car.type }}</div>
      <div class="fleet-meta">
        <div class="fleet-price">
          {{ car.pricePerDay }} zł <span>/ doba</span>
        </div>
        <div class="fleet-tags">
          <span class="tag">{{ car.seats }} osób</span>
          <span v-for="tag in car.tags" :key="tag" class="tag">{{ tag }}</span>
        </div>
      </div>
    </div>
  </div>
</template>
 
<script setup lang="ts">
export interface Car {
  id: number
  model: string
  type: string
  pricePerDay: number
  seats: number
  tags: string[]
}
 
defineProps<{ car: Car }>()
defineEmits<{ select: [car: Car] }>()
</script>
 
<style scoped>
.fleet-card {
  background: #161616;
  border: 0.5px solid rgba(255, 255, 255, 0.08);
  border-radius: 14px;
  overflow: hidden;
  cursor: pointer;
  transition: border-color 0.2s;
}
 
.fleet-card:hover {
  border-color: rgba(201, 169, 110, 0.4);
}
 
.fleet-img {
  height: 140px;
  background: #1e1e1e;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;
}
 
.fleet-body {
  padding: 1rem 1.125rem;
}
 
.fleet-model {
  font-weight: 500;
  font-size: 0.95rem;
  color: #f0ede6;
  margin-bottom: 3px;
}
 
.fleet-type {
  font-size: 0.75rem;
  color: rgba(240, 237, 230, 0.4);
}
 
.fleet-meta {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 0.875rem;
  padding-top: 0.875rem;
  border-top: 0.5px solid rgba(255, 255, 255, 0.07);
}
 
.fleet-price {
  font-size: 1.1rem;
  font-weight: 500;
  color: #c9a96e;
}
 
.fleet-price span {
  font-size: 0.7rem;
  color: rgba(240, 237, 230, 0.35);
  font-weight: 400;
}
 
.fleet-tags {
  display: flex;
  gap: 5px;
  flex-wrap: wrap;
}
 
.tag {
  font-size: 0.65rem;
  padding: 3px 8px;
  border-radius: 100px;
  background: rgba(255, 255, 255, 0.06);
  color: rgba(240, 237, 230, 0.5);
  border: 0.5px solid rgba(255, 255, 255, 0.08);
}
</style>