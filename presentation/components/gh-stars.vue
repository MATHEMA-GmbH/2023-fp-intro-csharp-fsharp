<script setup lang="ts">
import { ref } from 'vue'

const props = defineProps({
  count: {
    default: "0",
  },
})

const counter = ref(props.count)
</script>

<template>
  <simple-icons-github class="text-xs text-gray-700 inline mb-1 ml-1"/> {{count}} stars
</template>
