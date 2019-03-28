var x = document.getElementById("myDialog");
            function showDialog() {
                x.show();
                x.style.zIndex = "10";
                document.getElementById("abc").style.opacity = 0.3;
            }

            function closeDialog() {
                x.close();
                document.getElementById("abc").style.opacity = 1;
            }