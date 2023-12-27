

INSERT [GestionTareasDB].[states_data].[StateTask] ([idStateTask], [stateName], [stateDescription], [state]) VALUES
     (NEWID(), N'Earring', 'Sin empezar la tarea',1)
    ,(NEWID(), N'Initiated', 'Se cambia a la etapa de iniciado',1)
    ,(NEWID(), N'In progress', 'Los desarrolladores estan en ello',1)
    ,(NEWID(), N'Finalized', 'Tarea finalizada',1)


    select * from [GestionTareasDB].[basic_data].TaskManager