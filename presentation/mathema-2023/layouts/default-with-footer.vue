<template>
  <div class="slidev-layout default-with-footer">
    <div class="my-auto w-full">
      <slot />

      <div class="w-11/12 fixed bottom-0 flex justify-between mb-2 text-xs footer">
        <span>{{ $slidev.configs.occasion }}</span>
        <span>{{ $slidev.configs.company }} - {{ $slidev.configs.presenter }} - {{ $slidev.configs.contact }}</span>
        <span style="min-width: 4rem;"><SlideCurrentNo /> / <SlidesTotal /></span>
        </div>
    </div>
  </div>
</template>
