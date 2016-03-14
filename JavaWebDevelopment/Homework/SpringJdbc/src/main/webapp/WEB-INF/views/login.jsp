<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Login</title>
	</head>
	<body>
		<form action="/lebank/login" method="POST">
			<p> Test usernames: <b>user</b>, <b>employee</b>. Test password: <b>asd</b></p>
			<p> ${output} </p>
			<table>
				<tr>
					<td>Username:</td>
					<td><input type="text" name="username" id="username"></td>
				</tr>
				<tr>
					<td>Password:</td>
					<td><input type="password" name="password" id="password" ></td>
				</tr>
			</table>
			<input type="submit" name="submit" value="Login">
		</form>
	</body>
</html>