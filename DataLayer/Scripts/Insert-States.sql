

INSERT [GestionTareasDB].[states_data].[StateTask] ([idStateTask], [stateName], [stateDescription], [state]) VALUES
     (NEWID(), N'Pendiente', 'Sin empezar la tarea',1)
    ,(NEWID(), N'Iniciado', 'Se cambia a la etapa de iniciado',1)
    ,(NEWID(), N'En Proceso', 'Los desarrolladores estan en ello',1)
    ,(NEWID(), N'Finalizado', 'Tarea finalizada',1)

