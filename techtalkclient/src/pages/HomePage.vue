<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <h1>TECHtalk</h1>
    </div>
    <div class="row">
      <form type="submit" @submit.prevent="createPost">
        <div class="form-group row justify-content-center">
          <input type="text"
                 class="form-control m-1"
                 id="title"
                 v-model="state.newPost.title"
                 placeholder="Name of Post.."
                 required
          >
          <textarea type="text"
                    class="form-control m-1"
                    id="body"
                    v-model="state.newBug.body"
                    placeholder="Any thoughts?..."
                    required
          />">
          <button type="submit" class="btn sb mt-2">
            Submit
          </button>
        </div>
      </form>
    </div>
    <div class="row">
      <PostsComponent v-for="post in state.posts" :key="post.id" :post-prop="post" />
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { postsService } from '../services/PostsService'
import { logger } from '../utils/Logger'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      user: computed(() => AppState.user),
      posts: computed(() => AppState.posts),
      newPost: {}
    })
    onMounted(async() => {
      try {
        await postsService.getPosts()
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state,
      async createPost() {
        try {
          await postsService.createBug(state.newBug)
          state.newBug = {}
          // router.push({ name: 'Bug', params: { id } })
        } catch (error) {
          logger.log(error)
        }
      }

    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
