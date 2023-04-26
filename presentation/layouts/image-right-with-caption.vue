
<script setup lang="ts">
import { computed } from 'vue'
import { handleBackground } from './layoutHelper'
const props = defineProps({
  image: {
    type: String,
  },
  imageCaption: {
    type: String,
  },
  class: {
    type: String,
  },
})
const style = computed(() => handleBackground(props.image))
</script>

<template>
  <div class="grid grid-cols-2 w-full h-full">
    <div class="slidev-layout" :class="props.class">
      <slot />
    </div>
    <div class="m-0" :style="style" style="color:black">
      {{props.imageCaption}}
    </div>
  </div>
</template>
