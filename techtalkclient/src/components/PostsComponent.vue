<template>
  <div class="posts-component">
    <h1>{{ postsProp }}</h1>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'

export default {
  name: 'PostsComponent',
  props: {
    postsProp: { type: Object, required: true }
  },
  setup(props) {
    return {
      account: computed(() => AppState.account)
    }
  }
}

</script>

<style>

</style>
