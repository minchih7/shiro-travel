<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import { computed } from 'vue';
import Options from './Options.vue';
import LoginOrRegister from './LoginOrRegister.vue';
import { useMemberStore } from '@/stores/memberStore';
import { useRouter, useRoute } from 'vue-router';
import Searcher from './Searcher.vue';
import { useAlertStore } from '@/stores/alertStore';
import FloatingCart from '@/views/Cart/components/FloatingCart.vue';
import FloatingMemberCard from '@/views/Member/components/FloatingMemberCard.vue';

const memberFirstLetter = computed(() => {
    // 返回會員帳號的第一個字母
    return memberStore.account[0];
});

const isFloatingCartVisible = ref(false);
const showFloatingCart = () => {
    isFloatingCartVisible.value = true;
};
const hideFloatingCart = () => {
    isFloatingCartVisible.value = false;
};

const iconRef = ref(null); // 用于引用<v-icon>
const iconPosition = ref({ top: 0, left: 0 }); // 用于存储位置信息

onMounted(() => {
    const updatePosition = () => {
        if (iconRef.value) {
            const { top, left } = iconRef.value.getBoundingClientRect();
            iconPosition.value = { top, left };
            console.log(iconPosition.value);
        }
    };

    // 监听窗口大小变化
    window.addEventListener('resize', updatePosition);

    // 初始更新位置
    updatePosition();

    // 如果需要，也可以设置MutationObserver来监听DOM变化
});

onUnmounted(() => {
    // 清理
    window.removeEventListener('resize', updatePosition);
});

const alertStore = useAlertStore();
const router = useRouter();
const route = useRoute();

const memberStore = useMemberStore();

const dialog = ref(false);
const showLogin = ref(false); // 控制顯示哪個組件
const email = ref('');

// console.log(route.path);
// 只在 member 路由顯示搜尋框
const showSearcher = computed(() => {
    return route.path.startsWith('/member');
});

// 為按鈕增加取得會員資料方法
function getMemberInfo() {
    memberStore.getMemberInfo();
}
function Logout() {
    memberStore.logout();
}
function toTicket() {
    router.push('/attraction_ticket');
}

// 確認是否登入
function checkLogin() {
    // 如果為尚未登入狀態，則顯示 Options 組件， 將 showLogin 設為 false
    if (!memberStore.isLoggedIn) {
        showLogin.value = false;
    }
    dialog.value = true;
}

// 定義一個方法來切換顯示的組件
function toggleShowLogin() {
    showLogin.value = !showLogin.value;
}

// 關閉對話框
function closeDialog() {
    dialog.value = false;
}

// 使用 router to 跳轉到指定路由
function toHome() {
    router.push('/');
}

const drawer = ref(false);

const items = ref([
    { title: 'Foo', value: 'foo' },
    { title: 'Bar', value: 'bar' },
    { title: 'Fizz', value: 'fizz' },
    { title: 'Buzz', value: 'buzz' },
]);
</script>

<script>
export default {
    data: () => ({
        items: [
            { title: 'Click Me' },
            { title: 'Click Me' },
            { title: 'Click Me' },
            { title: 'Click Me 2' },
        ],
    }),
};
</script>
<template>
    <v-app-bar :elevation="0" class="app-bar-flex">
        <v-alert
            class="fixed-alertStore"
            :title="alertStore.alert.message"
            :type="alertStore.alert.type"
            v-model="alertStore.alert.show"
            closable
        ></v-alert>

        <!-- 將標題放在最左邊 -->
        <v-app-bar-title>
            <v-row>
                <v-col
                    cols="2"
                    class="font-weight-bold text-h4 webSiteTitle"
                    style="color: RGB(38, 190, 201)"
                    @click="toHome"
                >
                    小白旅遊
                </v-col>
                <v-col
                    cols="4"
                    style="height: 64px; padding-left: 0"
                    v-if="showSearcher"
                >
                    <Searcher />
                </v-col>
            </v-row>
        </v-app-bar-title>

        <!-- 使用flex容器包裹右邊的兩個元件，並利用CSS控制排列 -->
        <div class="flex-right">
            <v-icon
                v-if="memberStore.isLoggedIn"
                @click="toTicket"
                icon="mdi-ticket-confirmation-outline"
                class="pe-10 ticket"
                style="
                    :hover {
                        cursor: pointer;
                    }
                "
            />
            <!-- <v-menu
                transition="slide-y-transition"
                location="bottom right"
                :close-on-content-click="false"
                open-on-hover
            >
                <template v-slot:activator="{ props }">
                    <v-icon
                        v-bind="props"
                        class="pe-4 cart"
                        icon="mdi-cart-outline"
                        style="
                            :hover {
                                cursor: pointer;
                            }
                        "
                    ></v-icon>
                </template>
                <FloatingCart />
            </v-menu> -->

            <!-- <v-icon
                icon="mdi-cart-outline"
                class="pe-4 cart"
                style="
                    :hover {
                        cursor: pointer;
                    }
                "
            ></v-icon> -->

            <v-btn v-if="!memberStore.isLoggedIn" @click="checkLogin">
                <div class="font-weight-bold" style="color: gray">
                    登入/註冊
                </div>
            </v-btn>

            <v-menu
                transition="slide-y-transition"
                location="bottom right"
                v-if="memberStore.isLoggedIn"
            >
                <template v-slot:activator="{ props }">
                    <v-avatar
                        v-bind="props"
                        color="rgba(38, 190, 201,1)"
                        size="40"
                        class="ma-3"
                        :text="memberFirstLetter"
                    >
                    </v-avatar>
                </template>
                <FloatingMemberCard />
            </v-menu>
        </div>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" location="right" temporary>
        <v-list :items="items"></v-list>
    </v-navigation-drawer>

    <!-- 註冊及登入彈出窗口 -->
    <v-dialog
        v-model="dialog"
        transition="dialog-top-transition"
        class="dialog-vertical-top overflow-y-auto"
        max-width="450px"
    >
        <template v-slot:default="{ isActive }">
            <v-card class="d-flex overflow-hidden rounded-2" elevation="8">
                <template v-slot:append>
                    <div
                        style="
                            background-color: RGB(38, 190, 201);
                            width: 450px;
                            position: absolute;
                            top: 0;
                            left: 0;
                            z-index: 1000;
                            height: 10px;
                        "
                    ></div>
                    <div class="">
                        <v-btn
                            icon="$close"
                            size="large"
                            variant="text"
                            @click="isActive.value = false"
                        ></v-btn>
                    </div>
                </template>
                <div class="overflow-y-auto mt-0">
                    <v-container class="w-75 h-100 pa-0 align-center">
                        <!-- 根據 showLogin 的值決定顯示哪個組件 -->
                        <Options
                            v-if="!showLogin"
                            @show-login="toggleShowLogin"
                        />
                        <LoginOrRegister v-else @close-dialog="closeDialog" />
                    </v-container>
                </div>
            </v-card>
        </template>
    </v-dialog>
</template>

<style scoped>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}
/* :deep(.floatingCart) {
    top: 50px;
    left: 1005px;
} */
.ticket:hover {
    cursor: pointer;
}
.cart:hover {
    cursor: pointer;
}
:deep(.fixed-alertStore) {
    position: fixed;
    top: 5px;
    width: 300px;
    /* 置中顯示， 扣除目前自身寬度  */
    left: calc(50% - 150px);
    z-index: 1000;
}

.dialog-vertical-top {
    display: flex;
    align-items: flex-start;
    justify-content: center;
}

.app-bar-flex {
    /* height: 64px; */
    padding-left: 360px;
    /* 起始點設置較大的間距 */
    display: flex;
    justify-content: space-between;
    align-items: center;
    justify-content: center;
    /* 保留一個justify-content設定 */
}

.flex-right {
    padding-right: 380px;
    /* 起始點設置較大的間距 */
    display: flex;
    align-items: center;
}

/* 根據螢幕大小動態調整間距 */
@media (max-width: 1800px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 260px;
        padding-right: 290px;
    }

    :deep(.webSiteTitle) {
        margin-right: 60px;
    }
}

@media (max-width: 1600px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 165px;
        padding-right: 190px;
    }

    :deep(.webSiteTitle) {
        margin-right: 35px;
    }
}

@media (max-width: 1300px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 105px;
        padding-right: 140px;
    }
}

@media (max-width: 1200px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 40px;
        padding-right: 75px;
    }
}

@media (max-width: 992px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 80px;
        padding-right: 100px;
    }
}

@media (max-width: 768px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 50px;
        padding-right: 60px;
    }
}

@media (max-width: 678px) {
    .app-bar-flex,
    .flex-right {
        padding-left: 0px;
        padding-right: 0px;
    }
}
</style>
