# NoteApp-SantiagoGonzalez Documentación
# PASOS BASICOS DE CREACION DE PROYECTO

1 PASO:

De primeras debemos elegir un espacio donde haremos la creación de nuestro proyecto, donde la iniciaremos en la terminal y de ahí para inicializar el proyecto debemos ingresar lo siguiente "dotnet new list" donde nos dará un listado de plantillas

2 PASO:

Apartir de esto realizaremos este comando "dotnet new sln" que nos dará la solución principal del programa, que pondrá automaticamente el nombre de la carpeta de donde estemos

3 PASO:

Crearemos al proyecto la webapi API con el siguiente comando "dotnet new webapi -o API", despúes de esto tendremos que agregar al proyecto la API como una solucion global haciendo lo siguiente,ejecutamos este comando "dotnet sln add .\API\"

4 PASO: 

Crearemos al proyecto una clase libreria, primero debemos salir de la carpeta API que anteriormente entramos y ahora en la carpeta general del proyecto pondrémos este comando 
"dotnet new classlib -o Infrastructure", donde tendrémos que agregar esta nueva carpeta a la solucion del proyecto. Esto lo hacemos ingresando a la carpeta Infrastructure (cd Infrastructure) y finalmente colocando este comando "dotnet sln add .\Infrastructure\"

5 PASO:

Finalmente crearemos al proyecto una nueva clase libreria, en este caso en la carpeta principal de proyecto colocaremos este comando "dotnet new classlib -o Core" donde de nuevo debemos entrar a esa carpeta y poner el siguiente comando "dotnet sln add .\Core\"

6 PASO: 

Para ver todos los proyectos asociados a la solucion ponemos "dotnet sln list", si aparecen los 3 proyecto anteriormente creados (Infrastructure, Core y API) tenemos todo bien.

7 PASO:

Apatir de aca debemos relacionar Core con Infrastructure y Infrastructure con API, para esto, primero debemos entrar a la carpeta Infrastructure y poner el siguiente comando "dotnet add reference ..\Core\" despues de eso salimos de esa carpeta y entramos a API donde pondremos este comando "dotnet add reference ..\Infrastructure\"

8 PASO: 

Acá ya podemos usar visual estudio code, basta con volver a la carpeta principal y poner "code .", una vez dentro vamos a la terminal e instalamos o actualizamos herramientas con el siguiente comando "dotnet tool install --global dotnet-ef"

9 PASO:

Una vez dentro tenemos que descargar una extensión llamada Nutget Gallery donde y buscaremos "Microsoft.EntityFrameworkCore" y lo instalaremos en Infrastructure.csproj y luego buscaremos "Pomelo.EntityFrameworkCore.MySql" el cual instalaremos en API.csproj

Tambien podemos omitirnos el dolor de cabeza y hacer lo siguiente, en nuestra terminal de visual entrar a la carpeta API, copiar el siguiente codigo y ejecutar

+ dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.11
+ dotnet add package Microsoft.EntityFrameworkCore --version 7.0.11
+ dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.11
+ dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
+ dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
+ dotnet add package Serilog.AspNetCore --version 7.0.0
+ dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
+ dotnet add package AspNetCoreRateLimit --version 5.0.0

Luego entramos en la carpeta Infrastructure y ejecutaremos lo siguiente

+ dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
+ dotnet add package Microsoft.EntityFrameworkCore --version 7.0.11
+ dotnet add package CsvHelper --version 30.0.1

EN ESTE MOMENTO TENDRÉMOS LAS BASES DE NUESTRO PROYECTO CREADAS 

RECOMENDACIONES:

+ Podemos eliminar los archivos "Class1.cs" ya que no son necesarios
+ Eliminar la etiqueta <Nullable> de los archivos csproj

# CREACION DE CARPETAS NECESARIAS PARA PROYECTO

1. De primeras en la carpeta Infrastructure vamos a crear 3 carpetas Data, Repositories y UnitOfWork.
+ Dentro de la carpeta Data vamos a crear una carpeta llamada Configuration
2. En la carpeta Core, debemos crear las siguientes carpetas (Entities e Interfaces)
3. En la carpeta API, crearemos la carpeta Extensions y Profiles 


# ESTABLECIENDO NUESTRO PARAMETRO DE CONEXION

Dentro de nuestra carpeta API debemos ingresar unas lineas de codigo que enlazarán a nuestra base de datos, lo que haremos es entrar tanto en "appsettings.Development.json" y a "appsettings.json" y escribir los siguiente dependiendo de nuestra configuracion:

    "ConnectionStrings": {
    "MySqlConex": "server=localhost;user=root;password=123456;database=NombreDeBaseDeDatos"
    }

# CREACION DE CONTEXTO (ESTABLECE LA NEGOCIACION ENTRE LA BASE DE DATOS Y LA API)

Dentro de nuestra carpeta Infrastructure/Data, crearemos un nuevo archivo tipo class, donde tendrá como nombre el nombre del proyecto con junto a la palabra Context (NombreContext), donde una vez creado, agregamos como heredación "DbContext", donde al hacer eso, se debe importar automaticamente nuestra libreria using "Microsoft.EntityFrameworkCore"

+ Recordar eliminar los corchetes del namespace y colocarle punto y coma 

			namespace Infrastructure.Data;


Una vez hecho esto, dentro de nuestra clase crearemos el constructor de la clase, le daremos click izquierdo le daremos en "Refactor" y le daremos en 
+ Generate constructor 'NombreProyecyoContext(options)'

Finalmente como proceso automatico debemos crear el metodo para la estructura de nuestras tablas, en este caso copiar y pegar dentro de "public class NombreProyectoContext : DbContext" xd 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

Si aparece un error en Assembly, debemos hacer un quick fix donde haga uso de "System.Reflection"

Despúes de este paso, debemos inyectar la conexión a la base de datos por medio del archivo "Program.cs" donde entraremos a este archivo y antes de la declaracion de la variable app pegaremos este codigo cambiando las cosas dependiendo del proyecto

    builder.Services.AddDbContext<ArchivoDeContexto>(options => 
    {
   	string connectionString = 	builder.Configuration.GetConnectionString("MySqlConex");
    	options.UseMySql(connectionString, 	ServerVersion.AutoDetect(connectionString));
    });

Tener en cuenta que si aparecen errores, debemos importar tanto "Infrastructure.Data" como "Microsoft.EntityFrameworkCore".


# PASOS DE CREACION DE ENTIDAD EN EL PROYECTO

RECOMENDACION PRINCIPAL: 

Si la mayoria de nuestras entidades tendrán una llave principal autoincremental, es mejor hacer una entidad llamada "BaseEntity" donde declararemos un atributo de nombre "Id", el entity Framework tomará esto como una llave principal autoincrementar, ya luego en las entidades que necesitemos una llave principal autoincremental, solamente heredamos en la clase de la entidad el "BaseEntity". Esto al igual funciona con algún otro atributo que todas las entidades contengan.

1 PASO: 

En mi carpeta Core/Entities debo ingresar una nuevo archivo de tipo class donde le pondremos los atributos con el tipo de dato, facilitando escribo propt "public tipoDato NombreAtributo { get; set; }", tener en cuenta el punto anterior.

2 PASO: 

En mi carpeta Data en el archivo de "Contex" estarémos definiendo nuestra entidad para el entity Framework, en este caso agregaremos algo asi a nuestra clase "public DbSet<NombredeEntidad> NombreEntidadEnPlural { get; set; }"


# CREACION DE CONFIGURACIONES PARA ENTIDADES

En primer paso dentro de nuesta carpeta Configurations ubicada dentro de Data, crearemos un archivo por cada entidad creada, con la palabra Configuration al final (EntidadConfiguration), cuando las creamos debemos heredar "IEntityTypeConfiguration<Entidad>", donde dentro de nuestros diamantes pondremos el nombre de la entidad de esa configuración.

Nos aparecerá error, lo que debemos hacer es refactorizar e implementar interfaz, apartir de ahora trabajaremos dentro de nuesta interfaz creada.

Ahora las configuraciones dependen de la entidad pero en general todas son parecidas, pero cosas a recalcar

	builder.ToTable("NombredelaTabla") --Creamos el nombre de la tabla

	builder.HasKey(p => p.Id);
    builder.Property(p => p.Id);  -- Definimos la llave principal de nuestra entidad

	builder.Property(p => p.Nombre) -- Nombre del atributo que queremos definir
    .IsRequired() 		        -- Si es requerido, sino lo omitimos
    .HasMaxLength(50)  		-- Este es la cantidad de caracteres que contendrá como maximo

    builder.Property(p => p.FechaCreacion)
    .HasColumnType("date");  		-- Atributo tipo fecha


Ahora con las llaves foraneas tener en cuenta que en la entididad donde irá la llave foranea debe tener un atributo de tipo Entidad, esta entidad será la entidad de la llave foranea, donde esta entidad tendrá un atributo ICollection<NombreEntidadMuchos> para entender mejor ver el ejemplo con Departamento y Pais, ya que un Departamento existe en un Pais y un Pais tiene muchos departamentos. (Uno a muchos)

	-- Entidad Pais debe tener una coleccion de Departamento
	
	public ICollection<Departamento> Departamentos { get; set; } 

	-- Entidad Departamento debe tener un Id de Pais y un atributo tipo Pais

	public int IdpaisFk { get; set; }

    public Pais Paises { get; set; }

Ya con esto tengo la relacion uno a muchos.
Ahora para hacer esto en la configuracion, en la configuracion de la entidad que contiene las llaves foraneas debemos hacer algo así 

    builder.HasOne(p => p.Paises) -- Este paises es el nombre del atributo que es de tipo Pais
                                       que existe dentro de la entidad Departamento

    .WithMany(p => p.Departamentos) -- La entidad pais tiene la coleccion con nombre Departamentos
    .HasForeignKey(p => p.IdpaisFk); -- Finalmente en la entidad Departa tiene la llave IdPais


Para finalizar esta parte, revisar si la entidad ya ha sido ingresada al Contexto, si es así seguir con las interfaces.

# -- CREACION DE INTERFACES

Una vez hecha las configuraciones de todas las entidades, debemos realizar dentro de la carpeta Core/Interfaces la interfaz principal, la cuál será llamada IGenericRepository, a esta le heredaremos BaseEntity, pero de una manera distinta. Algo así

	public interface IGenericRepository<T> where T : BaseEntity

Hecho esto, dentro de nuestra clase debemos realizar las definiciones de los metodos que luego complementaremos en GenericRepository, para esto debemos implementar el siguiente código

	Task<T> GetByIdAsync(int id);
	Task<IEnumerable<T>> GetAllAsync();
	IEnumerable<T> Find(Expression<Func<T, bool>> expression);
	void Add(T entity);
	void AddRange(IEnumerable<T> entities);
	void Remove(T entity);
	void RemoveRange(IEnumerable<T> entities);
	void Update(T entity);

Ya una vez hecho esto, creamos el resto de Interfaces para todas la entidades que tengamos, en este caso solamente debemos heredar "IGenericRepository<>" donde dentro de los diamantes pondremos el nombre de la entidad

Para finalizar, crearemos la Interfaz de UnitOfWork, donde dentro de nuestra clase debemos llamara todas las interfaces recien creadas (menos IGenericRepository) y nombrarlas en plural al igual que definirle el metodo {get}, para ejemplo, una de estas entidades sería así 

	ISubmodulo Submodulos {get;}

Por esta parte hemos terminado las interfaces ahora debemos hacer los repositorios de cada entidad.

# -- CREACION DE REPOSITORIOS

En general los repositorios llevan el mismo lo mismo, a lal clase se le hereda GenericRepository<>, dentro de nuestros diamantes debemos ingresar la entidad principal (Ej. <Departamento>), y a un lado separado por , se ingresa la interfaz de la entidad (Ej. IDepartamento)

Nos aparecerá un error en el nombre de la clase repositorio, debemos hacer un quick fix y generar el constructor, luego debemos hacer un contexto privado : 
	
	private readonly NombreArchivoContexto _context;

Dentro del constructor creado debemos igualar el _context al context

	_context = context

# -- CONFIGURACION DEL UNIT OF WORK 
Es parecido al GenericRepository, primero debemos hacer la interfaz del UnitOfWork y luego en la carpeta creada exclusivamente realizamos el UnitOfWork, donde en la interfaz estarán las interfaces de las entidades algo asi: 
	
    IPais Paises { get; }

Ya luego en UnitOfWork se debe realizar la configuracion de las entidades, es lo mismo para todas, algo asi 

	public IPais Paises
        {
            get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }

y finalmente tendrémos las ultimas 2 funciones, una Dispose y la otra SaveAsync, la que más nos interesa es la función SaveAsync, la cual será la siguiente: 

	public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
    	}

Con este ultimo pasó ya habrémos configurado nuestra unidad de trabajo, ahora crearemos las dependecias que serán inyectadas en el contenedor de dependencias.


# -- CREACION DE EXTENSIONS
Creando una carpeta llamada Extensions dentro de nuestra carpeta API, en la cual contendrá nuestra configuración de la política de Cors, la limitacion de peticiones de nuestros endpoint y finalmente nuestra inyeccion de las unidades de trabajo, el codigo que contendrá este archivo es el siguiente: 

	//Funcion de configuracion de Cors
	public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => 
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                );
            });

	//Funcion de configuracion de peticiones
        public static void ConfigureRateLimiting(this IServiceCollection services) 
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2 
                    }
                };
            });
        }
	
	    //Funcion que implementa nuestras unidades de trabajo
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

Es muy importante que en nuestra clase de ApplicationServices, sea una clase static, osea debe verse algo así: 

	public static class ApplicationServicesExtensions

Para finalizar debemos inyectar estas funciones en nuestro contenedor de dependencias, en primer lugar, debemos ingresar nuestros métodos antes de la creacion de la var = app, para evita algún fallo, en este caso debemos ingresar lo siguiente en nuestro archivo 

	builder.Services.ConfigureRateLimiting();
	builder.Services.ConfigureCors();
	builder.Services.AddApplicationServices();

Y ya luego de la var = app tendrémos que ingresar este codigo igualmente

	app.UseCors("CorsPolicy");
	app.UseIpRateLimiting();

Hata este punto ya ingresamos las configuraciones necesarias para nuestro proyecto, aunque en un momento debemos ingresar una más.

# -- CREACION DE PERFILES DTO 

1 PASO:

Como primer paso debemos crear una carpeta Dtos dentro de API

2 PASO:

Dentro de la carpeta Dtos debemos crear una clase por cada entidad donde queramos mostrar nuestra entidad de manera personalizada, ya sea solo mostrar nombre y ID sin el resto de atributos, etc...

Es importante tener en cuenta que el nombre de la clase debe tener el nombre de la entidad junto a Dto
(EntidadDto).

Al igual que debemos de si o si mostrar el Id Principal, al igual que si la entidad tiene llaves foraneas, lo ideal sería colocar el Id de las llaves foraneas. 

3 PASO:

Dentro de nuestra carpeta Profiles, crearemos una nueva clase de nombre "MappingProfiles", en esta heredaremos con dos puntos "Profile" //public class MappingProfiles : Profile , donde luego dentro de nuestra clase crearemos un metodo publico de nombre "MappingProfiles", que dentro contendrá un codigo que enlazará la entidad original con la entidad Dto, algo así: 

	//CreateMap<EntidadPrincipal,EntidadDto>().ReverseMap();

Y así debemos enlazar todas las entidades que hemos creado tipo Dto con las entidades originales :P
Finalmente debemos inyectar en el contenedor de dependencias el AutoMapper, lo implementamos antes de la definicion de la variable app, y escribiremos lo siguiente:
	
	builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

Ya con esto tendrémos todas la entidades y configuraciones hechas, ahora, realizar los Controladores de las entidades Dto

# -- CREACION DE CONTROLADOR PARA ENTIDADES 
1 PASO: 

En nuestra carpeta API debe exitir una carpeta llamada "Controllers", la cual contendrá todos los controladores de las entidades.

En primer lugar debemos dentro de esta carpeta debemos crear un nuevo archivo C# de tipo Controller Api, tendrá como nombre "BaseController", este nos dará ya la estructura de nuesto controlador base. Si queremos podemos modificar la ruta la route para realizar endpoints

2 PASO:

Empezaremos a crear nuestros controladores, los cuales todos deberan heredar el controlador base (BaseController), ya una ves hecho esto debemos ubicarnos encima del nombre de la clase y hacer click derecho, Refactorizar y generar el contructor.

3 PASO:

Una ves con nuestro contructor creado, debemos implementar los parametros que serían

+ IUnitOfWork _unitOfWork
+ IMapper _mapper

Y luego a cada uno darle click derecho, Refactorizar y elegir "Crear y asignar campo "UnitOfWork"" o "Crear y asignar campo Mapper". 

4 PASO: 

Empezaremos a crear nuestros endpoint que en total serían 5 por cada controlador, serían los siguientes

+ HttpGet
+ HttpGet("{id}")
+ HttpPost
+ HttpPut("{id}")
+ HttpDelete("{id}")

Cada uno tiene su método, y es importante implementarla de manera correcta 

# HttpGet

Este es el método mas sencillo de realizar, este es un método publico asinconrico que devolverá un Task con una coleccion de la entidad tipo Dto, dentro de nuestra funcion con el _unitOfWork nos traeremos toda la informacion de esta entidad y finalmente la retornamos de manera mapeada para mostrar sólo lo que queramos.

En codigo se vería algo así:

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EntidadDto>>> Get()
    {
        var BlockChain = await _unitOfWork.Entidades.GetAllAsync();
        return _mapper.Map<List<EntidadDto>>(Entidad);
    }

# HttpGet("{id}")

Este método es casi igual al anterior, lo que cambia es que en la funcion debemos implementar el parámetro id, el cual luego con el _unitOfWork buscaremos a partir del Id que me pasaron, finalmente retornamos el contenido mapeado 

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EntidadDto>> GetId(int id)
    {
        var entidad = await _unitOfWork.Entidades.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return _mapper.Map<EntidadDto>(entidad);
    }


# HttpPost

Con este método agregaremos contenido a nuesta tabla en la base de datos, en este metodo tendrá como parámetro la entidad tipo Dto. Donde iniciando el método debemos mapear el parámetro en tipo Entidad principal.

Luego inicializamos la variable de entidad.FechaCreacion con la fecha actual, y la añadimos a la entidad principal, ya luego realizamos el CreatedAtAction y realizamos el codigo ahi. 

Para finalizar mapeamos la entidad y la retornamos. 

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<BlockChainDto>> Post(BlockChainDto blockChainDto)
    {
        var blockChain = _mapper.Map<BlockChain>(blockChainDto);
        if (blockChain.FechaCreacion == DateTime.MinValue)
        {
            blockChain.FechaCreacion = DateTime.Now;
        }
        _unitOfWork.BlockChains.Add(blockChain);
        await _unitOfWork.SaveAsync();
        if (blockChain == null)
        {
            return BadRequest();
        }
        var dato = CreatedAtAction(nameof(Post), new { id = blockChainDto.Id }, blockChainDto);
        var retorno = await _unitOfWork.BlockChains.GetByIdAsync(blockChain.Id);
        return _mapper.Map<BlockChainDto>(retorno);
    }


# HttpPut("{id}")

Con este método lo que haremos es actualizar algún registro ya creado de nuesta tabla, para eso, pasaremos por parámetro el id principal de este registo al igual que por el Body Json nos dará la informacion a actualizar.

Una vez con estos datos validamos si no es nulo lo que nos entregaron, y si no es nulo, verificamos si el id del registro que pasaron es 0, si es así lo igualamos al Id que paasaron por parámetro. Ya finalizando se realiza el mappeo del registro de tipo Dto a tipo entidad principal, donde con _unitOfWork actualizamos, guardamos y retornamos mapeada la informacion. 

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<BlockChainDto>> Put(int id, [FromBody] BlockChainDto blockChainDto)
    {
        if (blockChainDto == null)
        {
            return BadRequest();
        }
        if (blockChainDto.Id == 0)
        {
            blockChainDto.Id = id;
        }
        if (blockChainDto.Id != id)
        {
            return NotFound();
        }

        if (blockChainDto.FechaModificacion == DateTime.MinValue)
        {
            blockChainDto.FechaModificacion = DateTime.Now;
        }
        var blockChains = _mapper.Map<BlockChain>(blockChainDto);
        _unitOfWork.BlockChains.Update(blockChains);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<BlockChainDto>(blockChainDto);
    }


# HttpDelete("{id}")

Para finalizar, tendrémos nuestro metodó de eliminar algún registro de nuestra tabla, para este método, debemos pasar por parámetro el id del registro que queremos eliminar, una vez hecho esto, debemos en una variable guardar el registro que buscamos por medio del _unitOfWork.Entidades.GetByIdAsync(id)

Luego validamos si esa variable es distinta de nula, porque si es nula debemos retornar un error 404, que significas que no ha sido encontrado el registro. En cambio si lo encuentra, con el mismo _unitOfWork.Entidades.Remove(variable) eliminamos el registro pasando como parámetro la variable anteriormente creada.

Finalizando simplemente le retornamos un NoContent().

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
        if (blockChain == null)
        {
            return NotFound();
        }
        _unitOfWork.BlockChains.Remove(blockChain);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }