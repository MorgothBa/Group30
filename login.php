<?php
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['username']) && isset($_POST['password'])) {
    $valid_username = 'user';
    $valid_password = 'password';

    $username = $_POST['username'];
    $password = $_POST['password'];

    if ($username === $valid_username && $password === $valid_password) {
        $_SESSION['username'] = $username;
        header('Location: main.html');
        exit;
    } else {
        echo '<p style="color: red;">Rossz felhasználónév vagy jelszó.</p>';
        header('refresh:2;url=login.html');
        exit;
    }
} else {
    header('Location: login.html');
    exit;
}

?>
