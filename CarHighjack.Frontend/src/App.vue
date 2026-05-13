<template>
  <AddCar v-if="page === 'add'" />
  <Homepage v-else />
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Homepage from './Homepage.vue'
import AddCar from './AddCar.vue'

const page = ref('home')

window.addEventListener('navigate', (e: any) => {
  page.value = e.detail
})
</script>