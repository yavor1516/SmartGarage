<template>
    <div class="header">
        <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="125" height="125" />
        
        <!-- Add navigation links or other header content here -->
        <nav class="navi">
            <RouterLink to="/">Home</RouterLink>
            <RouterLink to="/about">About</RouterLink>
            <RouterLink to="/login">Login</RouterLink>
            <RouterLink to="/profile">Profile</RouterLink>
            <RouterLink to="/dashboard">Dashboard</RouterLink>
            <a href="/profile">1 </a>
            <a href="/">2 </a>
        </nav>
    </div>
</template>

<script>

    export default {

        name: 'HeaderComponent',

        
        // Add component logic here if needed
    }
</script>

<style scoped>
    .header {
        background-color: #333;
        color: #fff;
        display: flex;
        justify-content: space-between;
        align-items: center;
        height: 80px;
        padding: 0 20px; /* Add some padding to avoid elements sticking to edges */
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
    }

    .logo {
        width: 60px;
        height: 60px;
    }

    .navi {
        display: flex;
        justify-content: flex-end;
        align-items: center;
    }

        .navi a {
            color: #fff;
            margin-left: 20px; /* Add some space between navigation links */
            text-decoration: none;
        }
</style>