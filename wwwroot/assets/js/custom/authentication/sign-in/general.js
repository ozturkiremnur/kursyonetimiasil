"use strict";
var KTSigninGeneral = function () {
    var t, e, i;
    return {
        init: function () {
            t = document.querySelector("#kt_sign_in_form"), e = document.querySelector("#kt_sign_in_submit"), i = FormValidation.formValidation(t, {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: "Kullanici Adi Gerekli"
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "Sifre gerekli"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger,
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row"
                    })
                }
            }), e.addEventListener("click", (function (n) {
                n.preventDefault(), i.validate().then((function (i) {
                    "Valid" == i ? (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, setTimeout((function () {
                        //Giriþ yap butonuna bastýktan sonra bu kýsým çalýþacak
                        var kullaniciAdi = t.querySelector('[name="email"]').value;
                        var parola = t.querySelector('[name="password"]').value;

                        //Ajax kodlarý burada baþlýyor...........
                        $.ajax({
                            url: "/Login/loginKontrolJson/",
                            type: "POST",
                            data: {
                                "username": kullaniciAdi, "password": parola
                            },
                            success: function (returnData) {

                                if (returnData["status"] == "Error") {
                                    // Show error popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                                    Swal.fire({
                                        text: returnData["message"],
                                        icon: "error",
                                        buttonsStyling: false,
                                        confirmButtonText: "Tekrar Giris yapmayi dene!",
                                        customClass: {
                                            confirmButton: "btn btn-primary"
                                        }
                                    });

                                }
                                else {
                                    Swal.fire({
                                        text: returnData["message"],
                                        icon: "Success",
                                        buttonsStyling: false,
                                        customClass: {
                                            confirmButton: "btn btn-primary"
                                        }
                                    }).then(function (result) {
                                        if (result.isConfirmed) {
                                            form.querySelector('[name="email"]').value = "";
                                            form.querySelector('[name="password"]').value = "";
                                            //form.submit(); // submit form
                                        }
                                    });
                                    // Your application has indicated there's an error
                                    window.setTimeout(function () {

                                        // Move to a new location or you can do something else
                                        window.location.href = "../../Home/Index";

                                    }, 1500);
                                }
                            },
                            beforeSend: function () {
                                $(".loaderDiv").show();
                                $(".loader").show();
                            },
                            complete: function () {
                                $(".loaderDiv").hide();
                                $(".loader").hide();
                            },
                            error: function (xhr, status, err) {
                                if (xhr.status === 999) {
                                    noAuthorize(this.url);
                                }
                            }
                        });
                        //ajax kodlarý burada bitiyor......
                        e.removeAttribute("data-kt-indicator"), e.disabled = !1, Swal.fire({
                            text: "Basariyla giris yaptiniz!",
                            icon: "success",
                            buttonsStyling: !1,
                            confirmButtonText: "anladim",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        }).then((function (e) {
                            e.isConfirmed && (t.querySelector('[name="email"]').value = "", t.querySelector('[name="password"]').value = "")
                        }))
                    }), 2e3)) : Swal.fire({
                        text: "Maalesef bazi hatalar algilandi, lutfen tekrar deneyin.",
                        icon: "error",
                        buttonsStyling: !1,
                        confirmButtonText: "anladim",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    })
                }))
            }))
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTSigninGeneral.init()
}));