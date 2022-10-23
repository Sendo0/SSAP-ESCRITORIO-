namespace Pruebas_Unitarias
{
    using Modelo;
    using Controlador;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearProfesional()
        {
            Usuario pruebaUser = new Usuario { contraseña = "1234", tipo = "PROFESIONAL", id_comuna = Int32.Parse("1"), direccion = "Las Manzanas 433" };
            Profesional pruebaProfesional = new Profesional { rut = "73.999.999-9", nombre = "Cesar" };
            Ctrl.crearUsuario(pruebaUser, pruebaProfesional);
            Profesional proValid = Profesional.filtro_rut("73.999.999-9");
            Assert.AreEqual("Cesar", proValid.nombre.ToString());
        }

        [TestMethod]
        public void ModificarProfesional()
        {
            Profesional proPrueba = Profesional.filtro_rut("73.999.999-9");
            Usuario usuPrueba = Usuario.filtro_id(proPrueba.id_usuario);
            proPrueba.nombre = "Carlos";
            Ctrl.modificarUsuario(usuPrueba, proPrueba);
            Profesional proValid = Profesional.filtro_rut("73.999.999-9");
            Assert.AreEqual("Carlos", proValid.nombre.ToString());
        }

        [TestMethod]
        public void DeshabilitarProfesional()
        {
            Profesional proValid = Profesional.filtro_rut("73.999.999-9");
            Ctrl.estadoUsuario(proValid.id_usuario);
            Usuario pruebaUsuario = Usuario.filtro_id(proValid.id_usuario);
            Assert.AreEqual(false, pruebaUsuario.estado);
        }

        [TestMethod]
        public void CrearCliente()
        {
            Usuario pruebaUser = new Usuario { contraseña = "1234", tipo = "CLIENTE", id_comuna = Int32.Parse("3"), direccion = "Las Peras 433" };
            Cliente pruebaCli = new Cliente { rut = "63.888.888-8", nombre_empresa = "Polpaico", rubro_empresa = "Cemento", cant_trabajadores = Int32.Parse("102") };
            Contrato pruebaCont = new Contrato { costo_base = Int32.Parse("123654"), fecha_firma = DateTime.Now, ultimo_pago = DateTime.Now, CLIENTE_rut = "63.888.888-8", PROFESIONAL_rut = "73.999.999-9" };
            Ctrl.crearUsuario(pruebaUser, pruebaCli, pruebaCont);
            Cliente cliValid = Cliente.filtro_rut("63.888.888-8");
            Assert.AreEqual("Polpaico", cliValid.nombre_empresa.ToString());
        }

        [TestMethod]
        public void ModificarCliente()
        {
            Cliente cliPrueba = Cliente.filtro_rut("63.999.999-9");
            Usuario usuPrueba = Usuario.filtro_id(cliPrueba.id_usuario);
            cliPrueba.nombre_empresa = "Tricolor";
            Ctrl.modificarUsuario(usuPrueba, cliPrueba);
            Cliente cliValid = Cliente.filtro_rut("63.999.999-9");
            Assert.AreEqual("Tricolor", cliValid.nombre_empresa.ToString());
        }

        [TestMethod]
        public void DeshabilitarCliente()
        {
            Cliente cliValid = Cliente.filtro_rut("63.888.888-8");
            Ctrl.estadoUsuario(cliValid.id_usuario);
            Usuario pruebaUsuario = Usuario.filtro_id(cliValid.id_usuario);
            Assert.AreEqual(false, pruebaUsuario.estado);
        }

        
    }
}